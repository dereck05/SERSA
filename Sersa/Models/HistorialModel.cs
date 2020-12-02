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
using System.Threading.Tasks;

namespace Sersa.Models
{
    public class HistorialModel
    {
        internal DBConnector Database { get; set; }

        public HistorialModel() { }

        internal HistorialModel(DBConnector db)
        {
            Database = db;
        }

        public IConfigurationRoot GetConnection()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();

            return builder;
        }

        public async Task InsertAsync() 
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Historial` (`nombre`, `fecha`, `url`) VALUES (@nombre, @fecha, @url)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@nombre", "nombreEj");
            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@url", "https://www.google.com/");
            await cmd.ExecuteNonQueryAsync();
        }

        public List<Historial> llenarTablaHistorial()
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "";
            int id = Autenticacion.get_idUsuario();
            sql = "select h.id, h.nombre,h.fecha,h.identificadores from sersa.Historial h inner join sersa.InformexUsuario i on h.id = i.idInforme where i.idUsuario = " + id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Historial> lista = new List<Historial>();

            while (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Historial temp = new Historial();
                    string col1Value = rdr[0].ToString();
                    temp.id = col1Value;
                    string col2Value = rdr[1].ToString();
                    temp.nombre = col2Value;
                    string col3Value = rdr[2].ToString();
                    double col3Double = Double.Parse(col3Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col3Double).ToLocalTime();
                    temp.Fecha = colDateTime.ToString("dd/MM/yyyy");
                    string col4Value = rdr[3].ToString();
                    temp.identificadores = col4Value;
                    lista.Add(temp);
                }
                rdr.NextResult();
            }
            return lista;
        }

        public string nombreAsada(string id)
        {
            //Conexion escondida
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Irsass").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "SELECT Nombre from ASADA WHERE ID=@id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            string nombre = "";
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    nombre = rdr[0].ToString();
                }
                rdr.NextResult();
            }
            return nombre;

        }
        public void guardarInforme(string titulo, string listIds, long fecha)
        {
            //Conexion escondida
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "INSERT INTO Historial (nombre,fecha,identificadores) values( @titulo,@fecha, @identificadores)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.Parameters.AddWithValue("@titulo", titulo);
            cmd.Parameters.AddWithValue("@identificadores", listIds);
            cmd.ExecuteReader();


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
            foreach (string idList in listaID)
            {
                string sql = "SELECT fecha,acueducto,encargado,info_general,infraestructura,imagen,comentarios,tipo_formulario,asada FROM Formulario WHERE id = @formID";
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
                        temp.fecha = date;
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
                        string col9Value = rdr[8].ToString();
                        temp.asada = col9Value;
                        lista.Add(temp);
                    }
                    rdr.NextResult();
                }
                rdr.Close();
            }


            //Calcula los si y no
            foreach (InformeResponse inf in lista)
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
                if (inf.si == 0) { inf.riesgo = "Nulo"; }
                else if (inf.si <= 2) { inf.riesgo = "Bajo"; }
                else if (inf.si <= 4) { inf.riesgo = "Intermedio"; }
                else if (inf.si <= 7) { inf.riesgo = "Alto"; }
                else if (inf.si <= 10) { inf.riesgo = "Muy Alto"; }
            }


            return lista;


        }


        public ActionResult buildPDF(List<InformeResponse> lista, string nombreAsada)
        {
            MemoryStream ms = new MemoryStream();
            PdfWriter pw = new PdfWriter(ms);

            PdfDocument pdfDocument = new PdfDocument(pw);
            Document doc = new Document(pdfDocument, PageSize.LETTER);
            doc.Add(new Paragraph("Reporte " + nombreAsada).SetFontSize(20).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontColor(new DeviceRgb(4, 124, 188)));
            foreach (InformeResponse item in lista)
            {
                Preguntas preguntasObj = TipoFormulario(item.tipo);

                doc.Add(new Paragraph(item.acueducto).SetFontSize(15).SetBold());
                doc.Add(new Paragraph("Fecha: " + item.fecha).SetFontSize(12));
                doc.Add(new Paragraph("Encargado: " + item.encargado).SetFontSize(12).SetPaddingBottom(2));
                doc.Add(new Paragraph("Respuestas ").SetFontSize(12).SetUnderline());

                var infra = JsonConvert.DeserializeObject<Dictionary<string, string>>(item.infraestructura);
                foreach (var kv in infra)
                {
                    if (kv.Key == "P1")
                    {
                        doc.Add(new Paragraph(preguntasObj.p1 + ": " + kv.Value).SetFontSize(8));
                    }
                    else if (kv.Key == "P2")
                    {
                        doc.Add(new Paragraph(preguntasObj.p2 + ": " + kv.Value).SetFontSize(8));
                    }
                    else if (kv.Key == "P3")
                    {
                        doc.Add(new Paragraph(preguntasObj.p3 + ": " + kv.Value).SetFontSize(8));
                    }
                    else if (kv.Key == "P4")
                    {
                        doc.Add(new Paragraph(preguntasObj.p4 + ": " + kv.Value).SetFontSize(8));
                    }
                    else if (kv.Key == "P5")
                    {
                        doc.Add(new Paragraph(preguntasObj.p5 + ": " + kv.Value).SetFontSize(8));
                    }
                    else if (kv.Key == "P6")
                    {
                        doc.Add(new Paragraph(preguntasObj.p6 + ": " + kv.Value).SetFontSize(8));
                    }
                    else if (kv.Key == "P7")
                    {
                        doc.Add(new Paragraph(preguntasObj.p7 + ": " + kv.Value).SetFontSize(8));
                    }
                    else if (kv.Key == "P8")
                    {
                        doc.Add(new Paragraph(preguntasObj.p8 + ": " + kv.Value).SetFontSize(8));
                    }
                    else if (kv.Key == "P9")
                    {
                        doc.Add(new Paragraph(preguntasObj.p9 + ": " + kv.Value).SetFontSize(8));
                    }



                }
                doc.Add(new Paragraph("Comentarios: " + item.comentarios).SetFontSize(12));
                doc.Add(new Paragraph("Tipo de formulario: " + preguntasObj.tipo).SetFontSize(12));
                Cell cell = new Cell();
                cell.Add(new Paragraph("Riesgo " + item.riesgo).SetBorder(new SolidBorder(colorRiesgo(item.riesgo), 1)).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(14));
                doc.Add(cell);



            }

            doc.Close();

            byte[] bytesStream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(bytesStream, 0, bytesStream.Length);
            ms.Position = 0;

            return new FileStreamResult(ms, "application/pdf");
        }

        public Preguntas TipoFormulario(string t)
        {
            int caseSwitch = Int32.Parse(t);
            Preguntas p = new Preguntas();
            switch (caseSwitch)
            {
                case 1:
                    p.tipo = "Fuente Superficial";
                    p.p1 = "1. ¿Está la captación fuera de un área protegida o zona de conservación?";
                    p.p2 = "2. ¿Está la toma de agua desprovista de infraestructura que la proteja?";
                    p.p3 = "3. ¿Está el área alrededor de la toma sin cerca?";
                    p.p4 = "4. ¿Está la toma de agua ubicada dentro de alguna zona de actividad agrícola? (crítica)";
                    p.p5 = "5. ¿Existe alguna otra fuente de contaminación alrededor de la toma (letrinas, animales, viviendas, basura o industrias, etc.)? (Observar si aproximadamente a 200 metros a la redonda existen letrinas, animales, viviendas, basura) (crítica)";
                    p.p6 = "6. ¿Está la captación con acceso fácil de personas y animales?(crítica)";
                    p.p7 = "7. ¿Están las rejillas de la toma en malas condiciones (ausentes, quebradas y otros)?";
                    p.p8 = "8. ¿Existe presencia de plantas (raíces, hojas y otros) tapando las rejillas de la toma?";
                    p.p9 = "9. ¿Existen condiciones de deforestación y erosión en los alrededores de la toma de agua?";
                    p.p10 = "10. ¿Está ausente el desarenador después de la toma de agua?";
                    break;
                case 2:
                    p.tipo = "Fuente Naciente";
                    p.p1 = "1. ¿Está la naciente sin cerca de protección que impida el acceso de personas y animales a la captación (crítica)";
                    p.p2 = "2. ¿Está la captación de la naciente desprotegida abierta a la contaminación ambiental? (sin tapa o sin tanque de captación)";
                    p.p3 = "3. ¿Está la tapa de la captación construida en condiciones no sanitarias?";
                    p.p4 = "4. ¿Están las paredes y las losas superior e inferior de la captación con grietas? (critica)";
                    p.p5 = "5. ¿Se carece de canales para desviar el agua de escorrentía? (crítica)";
                    p.p6 = "6. ¿Carece la captación de respiraderos o tubería de rebalse con rejilla de protección?";
                    p.p7 = "7. ¿Se encuentran plantas (raíces, hojas, algas y otros) dentro de la captación de la naciente?";
                    p.p8 = "8. ¿Existen aguas estancadas sobre o alrededor de la captación? (crítica)";
                    p.p9 = "9. ¿Existe alguna fuente de contaminación alrededor de la captación? (Observar si aproximadamente a 200 metros a la redonda existen letrinas, animales, viviendas, basura)";
                    p.p10 = "10. ¿Se encuentra la captación ubicada en zonas con actividad agrícola o industrial? (crítica)";

                    break;
                case 3:
                    p.tipo = "Pozos";
                    p.p1 = "1. ¿Está el pozo sin cerca de protección que impida el acceso de personas y animales (crítica)";
                    p.p2 = "2. ¿Está el pozo desprotegido abierto a la contaminación ambiental? (sin caseta o sin tapa). (critica)";
                    p.p3 = "3. ¿Está la bomba en malas condiciones (sucia, mal funcionamiento)?";
                    p.p4 = "4. ¿Se carece de la curva de bombeo del fabricante de la bomba?";
                    p.p5 = "5. ¿Se carece de canales para desviar el agua de escorrentía? (crítica)";
                    p.p6 = "6. ¿Se carece con un tubo de 25-38 mm de diámetro para efectuar la medición de niveles de agua?";
                    p.p7 = "7. ¿Se encuentran plantas (raíces, hojas, algas y otros) dentro del pozo?";
                    p.p8 = "8. ¿Existen aguas estancadas sobre o alrededor del pozo? (crítica)";
                    p.p9 = "9. ¿Existe alguna fuente de contaminación alrededor del pozo? (Observar si aproximadamente a 200 metros a la redonda existen letrinas, animales, viviendas, basura)";
                    p.p10 = "10. ¿Se encuentra el pozo ubicado en zonas con actividad agrícola o industrial? (crítica)";
                    break;
                case 4:
                    p.tipo = "Tanques de Almacenamiento";
                    p.p1 = "1. ¿Están las paredes agrietadas (concreto) o herrumbradas (metálico)? (critica)";
                    p.p2 = "2. ¿Está la tapa del tanque de almacenamiento, construida en  condiciones no sanitarias? (critica)";
                    p.p3 = "3. ¿Es el borde de cemento alrededor del tanque menor a 1 metro?";
                    p.p4 = "4. ¿Está ausente o fuera de operación el sistema de cloración? (critica)";
                    p.p5 = "5. ¿Está el nivel del agua menor que 1/4 del volumen del tanque?";
                    p.p6 = "6. ¿Existen sedimentos, algas u hongos dentro del tanque? ";
                    p.p7 = "7. ¿Está ausente o defectuosa la cerca de protección?";
                    p.p8 = "8. ¿Carece la tapa de un sistema seguro de cierre (candado, cadena, tornillo)?";
                    p.p9 = "9. ¿Carece el tanque de respiraderos o tubería de rebalse con rejilla de protección? (critica)";
                    p.p10 = "10. ¿Existe alguna fuente de contaminación alrededor del tanque (letrinas, animales, viviendas, basura, actividad agrícola o industrial) (critica)";
                    break;
                case 5:
                    p.tipo = "Conduccion";
                    p.p1 = "1. ¿Existe alguna fuga en la línea de conducción? (crítica)";
                    p.p2 = "2. ¿Se encuentra la línea de conducción descubierta, con riesgo de ser alterada?";
                    p.p3 = "3. ¿Se encuentra la línea de conducción en lugares colindantes sin el adecuado soporte? (crítica)";
                    p.p4 = "4. ¿Se encuentran debidamente separadas las aguas provenientes de manantiales y nacientes con respecto a las aguas superficiales? (crítica)";
                    p.p5 = "5. ¿Existen variaciones significativas de presión en la red de conducción?";
                    p.p6 = "6. ¿La unión de la línea de conducción con la toma de agua o captación está asegurada contra posibles contaminaciones? (crítica)";
                    p.p7 = "7. ¿Carece de válvulas de control anterior a la entrada al tanque de almacenamiento?";
                    p.p8 = "8. ¿Existen hongos, moho, etc. en la superficie de las tuberías?";
                    p.p9 = "9. ¿Se Carece de sistema para purgar y desfogue de aire en la tubería de conducción? (crítica)";
                    p.p10 = "10. ¿Carecen de un esquema del sistema de conducción (planos o croquis)?";
                    break;
                case 6:
                    p.tipo = "Red de Distribucion";
                    p.p1 = "1. ¿Existen uniones ilícitas que pongan en riesgo la calidad del agua en la red de distribución? (crítica)";
                    p.p2 = "2. ¿Se carece de micromedidores?";
                    p.p3 = "3. ¿No se realizan pruebas periódicas de cloro residual en la red de distribución? (crítica)";
                    p.p4 = "4. ¿Se observan fugas visibles en alguna parte de la red de distribución? (crítico)";
                    p.p5 = "5. ¿Existen variaciones significativas de presión en la red de distribución?";
                    p.p6 = "6. ¿Se carece de válvulas de control de presiones y para realizar reparaciones en la red de distribución sin necesidad de quitar todo el servicio de agua a la comunidad?";
                    p.p7 = "7. ¿Existen interrupciones constantes en el servicio de distribución de agua? (crítica)";
                    p.p8 = "8. ¿Se carece de sistema para purgar en la tubería de distribución?";
                    p.p9 = "9. ¿Existe conexiones cruzadas de red de aguas negras con la red de distribución de agua potable? (crítica)";
                    p.p10 = "10. ¿Se carece de un esquema del sistema de distribución (planos o croquis)?";
                    break;
                case 7:
                    p.tipo = "Quiebragradientes";
                    p.p1 = "1. ¿Están las paredes agrietadas (concreto) o herrumbradas (metálico)? (crítica)";
                    p.p2 = "2. ¿Está la tapa de inspección construida en  condiciones no sanitarias?";
                    p.p3 = "3. ¿Es el borde de cemento alrededor del tanque menor a 1 metro?";
                    p.p4 = "4. ¿Existen sedimentos, algas u hongos dentro del tanque? (crítico)";
                    p.p5 = "5. ¿Está ausente o defectuosa la cerca de protección?";
                    p.p6 = "6. ¿Carece la tapa de un sistema seguro de cierre (candado, cadena, tornillo)?";
                    p.p7 = "7. ¿Carece el tanque de respiraderos o tubería de rebalse con rejilla de protección?";
                    p.p8 = "8. ¿Existe alguna fuente de contaminación alrededor del tanque (letrinas, animales, viviendas, basura, actividad agrícola o industrial)? (crítico)";
                    p.p9 = "9. ¿Se carece de válvula(s) de cierre para limpieza y/o reparación de la estructura?";
                    p.p10 = "10. ¿La estructura  carece de pintura de protección tanto externa como interna?";
                    break;
                case 8:
                    p.tipo = "Desinfeccion";
                    p.p1 = "1. ¿Se carece de una zona/caseta debidamente acondicionada para la preparación y aplicación del cloro? (critica)";
                    p.p2 = "2. ¿Carece el acueducto de bitácora de la dosificación del cloro? (crítica)";
                    p.p3 = "3. ¿Carece el operario de la capacitación necesaria para la preparación y aplicación de la cloración? (crítica)";
                    p.p4 = "4. ¿Se carece del equipo de protección necesaria para el personal operativo del sistema de cloración? (crítica)";
                    p.p5 = "5. ¿Se carece del equipo para la medición de cloro residual?";
                    p.p6 = "6. ¿Se carece de registros de la concentración y del caudal de la solución de cloro preparada y aplicada? (critica)";
                    p.p7 = "7. ¿Se carece de registros de los niveles de cloro residual en tanque(s) de almacenamiento?";
                    p.p8 = "8. ¿Se carece de registros de caudal del agua a ser clorada (caudal que ingresa al tanque donde se homogeniza el cloro)?";
                    p.p9 = "9. ¿Se carece de mantenimiento periódico del sistema de cloración?";
                    p.p10 = "10. ¿Se carece de registros de consumo de cloro día/semana/mes/año?";
                    break;

                case 9:
                    p.tipo = "Planta de potabilizacion";
                    p.p1 = "1. ¿Están las paredes agrietadas (concreto) o herrumbradas (metálico)? (critica)";
                    p.p2 = "2. ¿Es el borde de cemento alrededor de los tanques menor a 1 metro?";
                    p.p3 = "3. ¿Está la planta sin cerca de protección que impida el acceso de personas y animales? (crítica)";
                    p.p4 = "4. ¿Carecen los operarios de la capacitación necesaria para la operación y mantenimiento de la planta? (critica)";
                    p.p5 = "5. ¿Se carece de equipos para realizar las pruebas de laboratorio básicas para establecer la calidad del agua que ingresa a la planta parámetros Nivel I según la normatividad?";
                    p.p6 = "6. ¿Se carece de registros de la calidad del agua que ingresa a la planta? (critica)";
                    p.p7 = "7. ¿Se carece de registros de caudal del agua que ingresa a la planta? (critica)";
                    p.p8 = "8. ¿Carece la planta de bitácora donde se anoten las actividades realizadas durante cada jornada de la cuadrilla de operadores? (critica)";
                    p.p9 = "9. ¿Se carece de mantenimiento periódico de la planta?";
                    p.p10 = "10. ¿Se carece de un esquema del sistema de potabilización (planos o croquis)?";
                    break;
            }
            return p;
        }

        public DeviceRgb colorRiesgo(string riesgo)
        {
            DeviceRgb color = new DeviceRgb(0, 0, 0);

            if (riesgo == "Nulo")
            {
                color = new DeviceRgb(0, 0, 204);
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
