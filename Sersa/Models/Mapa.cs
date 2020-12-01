using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Newtonsoft.Json;

namespace Sersa.Models
{
    public class Mapa
    {
        internal DBConnector Database { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public int tipo { get; set; }
        public string acueducto { get; set; }
        public int riesgo { get; set; }

        public Mapa() { }
        public Mapa(string pLatitud, string pLongitud, int pTipo)
        {
            latitud = pLatitud;
            longitud = pLongitud;
            tipo = pTipo;
        }

        public IConfigurationRoot GetConnection()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();

            return builder;

        }

        internal Mapa(DBConnector db)
        {
            Database = db;
        }

        public List<Mapa> obtenerPuntos(long fechaInicio, long fechaFin, List<int> tipos) {

            string asada = Autenticacion.get_idAsada();

            string res = "";

            //Conexion escondida
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();

            res += "(";

            foreach (int tipo in tipos) {
                //res += "'";
                res += tipo.ToString();
                res += ",";
            }
            res.TrimEnd(',');
            res += ")";

            string sql1 = "SELECT f.tipo_formulario, f.latitud, f.longitud, f.acueducto, f.infraestructura FROM sersa.Formulario AS f WHERE (f.fecha BETWEEN @fechaI AND @fechaF) AND (f.tipo_formulario IN";
            sql1 += "(";
            foreach (int tipo in tipos) {
                sql1 += "'" + tipo.ToString() + "',";
            }
            string sql = sql1.Remove(sql1.Length - 1, 1);
            if (asada != null)
            {
                sql += ")) AND (f.asada = @asada) AND (f.latitud BETWEEN -90 AND 90) AND (f.longitud BETWEEN -180 AND 180)";
            }
            else {
                sql += ")) AND (f.latitud BETWEEN -90 AND 90) AND (f.longitud BETWEEN -180 AND 180)";
            }
            
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@fechaI", fechaInicio);
            cmd.Parameters.AddWithValue("@fechaF", fechaFin);
            cmd.Parameters.AddWithValue("@asada", asada);
            cmd.Parameters.AddWithValue("@res", res);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Mapa> lista = new List<Mapa>();

            while (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Mapa temp = new Mapa();
                    int col1Value = (int)rdr[0];
                    temp.tipo = col1Value;
                    string col2Value = rdr[1].ToString();
                    temp.latitud = col2Value;
                    string col3Value = rdr[2].ToString();
                    temp.longitud = col3Value;
                    string col4Value = rdr[3].ToString();
                    temp.acueducto = col4Value;
                    string col5Value = rdr[4].ToString();
                    int riesgoTotal = 0;

                    var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(col5Value);
                    foreach (var kv in dict)
                    {
                        if (kv.Value == "Si")
                        {
                            riesgoTotal++;
                        }

                    }

                    temp.riesgo = riesgoTotal;

                    lista.Add(temp);
                }
                rdr.NextResult();
            }
            return lista;
        }

    }
}
