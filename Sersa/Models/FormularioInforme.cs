using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace Sersa.Models
{
    public class FormularioInforme
    {
        internal DBConnector Database { get; set; }

        public string id { get; set; }
        public int fecha { get; set; }
        public string acueducto { get; set; }
        public FormularioInforme() { }
        public FormularioInforme(string idFormulario, string acueductoForm, int fechaForm)
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

        public List<FormularioInforme> obtenerFormularioInforme(int fechaI, int fechaF)
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
                    temp.fecha = col2Value;
                    string col3Value = rdr[2].ToString();
                    temp.acueducto = col3Value;
                    lista.Add(temp);
                }
                rdr.NextResult();
            }

            return lista;


        }
    }
}
