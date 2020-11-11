using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Newtonsoft.Json;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Geom;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;
using iText.Layout.Element;
using iText.Kernel.Colors;
using iText.Layout.Borders;

namespace Sersa.Models
{
    public class FormularioInforme
    {
        internal DBConnector Database { get; set; }

        public string id { get; set; }
        public string fecha { get; set; }
        public string acueducto { get; set; }
        public FormularioInforme() { }
        public FormularioInforme(string idFormulario, string acueductoForm, string fechaForm)
        {
            id = idFormulario;
            fecha = fechaForm;
            acueducto = acueductoForm;

        }
        public IConfigurationRoot GetConnection()

        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();

            return builder;

        }
        internal FormularioInforme(DBConnector db)
        {
            Database = db;
        }

        public List<FormularioInforme> obtenerFormularioInforme(long fechaI, long fechaF)
        {
            //Conexion escondida
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "SELECT id,fecha,acueducto FROM Formulario WHERE fecha between @fechaIni and @fechaFin";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@fechaIni", fechaI);
            cmd.Parameters.AddWithValue("@fechaFin", fechaF);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<FormularioInforme> lista = new List<FormularioInforme>();

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    FormularioInforme temp = new FormularioInforme();
                    string col1Value = rdr[0].ToString();
                    temp.id = col1Value;
                    int col2Value = (int)rdr[1];
                    var date = DateTimeOffset.FromUnixTimeSeconds(col2Value).DateTime.ToLocalTime().ToString("dd/MM/yyyy");
                    temp.fecha = date;
                    string col3Value = rdr[2].ToString();
                    temp.acueducto = col3Value;
                    lista.Add(temp);
                }
                rdr.NextResult();
            }

            return lista;


        }
        public List<InformeResponse> obtenerInformesSeleccionados(List<string> listaID)
        {
            //Conexion escondida
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            List<InformeResponse> lista = new List<InformeResponse>();

            //Obtiene los formularios seleccionados de la BD
            foreach ( string idList in listaID)
            {
                string sql = "SELECT fecha,acueducto,encargado,info_general,infraestructura,imagen,comentarios,tipo_formulario FROM Formulario WHERE id = @formID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@formID", idList);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.HasRows)
                {

                    while (rdr.Read())
                    {
                         
                        InformeResponse temp = new InformeResponse();
                        long col1Value = (int)rdr[0];
                        var date = DateTimeOffset.FromUnixTimeSeconds(col1Value).DateTime.ToLocalTime().ToString("dd/MM/yyyy");
                        temp.fecha= date;
                        string col2Value = rdr[1].ToString();
                        temp.acueducto = col2Value;
                        string col3Value = rdr[2].ToString();
                        temp.encargado = col3Value;
                        string col4Value = rdr[3].ToString();
                        temp.info_general = col4Value;
                        string col5Value = rdr[4].ToString();
                        temp.infraestructura = col5Value;
                        string col6Value = rdr[5].ToString();
                        temp.imagen = col6Value;
                        string col7Value = rdr[6].ToString();
                        temp.comentarios = col7Value;
                        string col8Value = rdr[7].ToString();
                        temp.tipo = col8Value;
                        lista.Add(temp);
                    }
                    rdr.NextResult();
                }
                rdr.Close();
            }


            //Calcula los si y no
            foreach( InformeResponse inf in lista)
            {
                var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(inf.infraestructura);
                foreach (var kv in dict)
                {
                    if (kv.Value == "Si")
                    {
                        inf.si = inf.si + 1;
                    }
                    if (kv.Value == "No")
                    {
                        inf.no = inf.no + 1;
                    }
                   
                }

                //!!!!!Calcula el riesgo!!!!!!!!!!
                if(inf.si == 0) { inf.riesgo = "Nulo"; }
                else if (inf.si <= 2 ) { inf.riesgo = "Bajo"; }
                else if (inf.si <= 4) { inf.riesgo = "Intermedio"; }
                else if (inf.si <= 7) { inf.riesgo = "Alto"; }
                else if (inf.si <= 10) { inf.riesgo = "Muy Alto"; }
            }


            return lista;


        }

        public ActionResult buildPDF(List<InformeResponse> lista)
        {
            MemoryStream ms = new MemoryStream();
            PdfWriter pw = new PdfWriter(ms);

            PdfDocument pdfDocument = new PdfDocument(pw);
            Document doc = new Document(pdfDocument, PageSize.LETTER);
            doc.Add(new Paragraph("Informe SERSA").SetFontSize(20).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontColor(new DeviceRgb(4, 124, 188)));

            foreach( InformeResponse item in lista)
            {
                doc.Add(new Paragraph("Acueducto " + item.acueducto).SetFontSize(15).SetBold());
                doc.Add(new Paragraph("Fecha: " + item.fecha).SetFontSize(12));
                doc.Add(new Paragraph("Encargado: " + item.encargado).SetFontSize(12).SetPaddingBottom(2));
                //doc.Add(new Paragraph("Informacion general: " + item.fecha).SetFontSize(12));

                //var info_gen = JsonConvert.DeserializeObject<Dictionary<string, string>>(item.info_general);
                //foreach (var kv in info_gen)
                //{


                //}
                doc.Add(new Paragraph("Comentarios: " + item.comentarios).SetFontSize(12));
                doc.Add(new Paragraph("Tipo de formulario: " + TipoFormulario(item.tipo)).SetFontSize(12));
                Cell cell = new Cell();
                cell.Add(new Paragraph("Riesgo "+item.riesgo).SetBorder(new SolidBorder(colorRiesgo(item.riesgo), 1)).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(14));
                doc.Add(cell);



            }

            doc.Close();

            byte[] bytesStream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(bytesStream, 0, bytesStream.Length);
            ms.Position = 0;

            return new FileStreamResult(ms, "application/pdf");
        }

        public string TipoFormulario(string t)
        {
            int caseSwitch = Int32.Parse(t);
            string res = "";
            switch (caseSwitch)
            {
                case 1:
                    res = "Fuente Superficial";
                    break;
                case 2:
                    res = "Fuente Naciente";
                    break;
                case 3:
                    res = "Pozos";
                    break;
                case 4:
                    res = "Tanques de Almacenamiento";
                    break;
                case 5:
                    res = "Conduccion";
                    break;
                case 6:
                    res = "Red de Distribucion";
                    break;
                case 7:
                    res = "Quiebragradientes";
                    break;
                case 8:
                    res = "Desinfeccion";
                    break;
                case 9:
                    res = "Planta de potabilizacion";
                    break;
            }
            return res;
        }

        public DeviceRgb colorRiesgo(string riesgo)
        {
            DeviceRgb color = new DeviceRgb(0, 0, 0);

            if (riesgo == "Nulo")
            {
                color = new DeviceRgb(0, 0,204);
            }
            else if (riesgo == "Bajo")
            {
                color = new DeviceRgb(102, 178, 255);
            }
            else if (riesgo == "Intermedio")
            {
                color = new DeviceRgb(0, 204, 0);
            }
            else if (riesgo == "Alto")
            {
                color = new DeviceRgb(255, 255, 0);
            }
            else if (riesgo == "Muy Alto")
            {
                color = new DeviceRgb(255, 0, 0);
            }

            return color;
        }
    }

    
}
