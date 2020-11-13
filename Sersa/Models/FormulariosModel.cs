using System;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Sersa.Models;
using System.Collections.Generic;
using Firebase.Storage;
using System.IO;

namespace Sersa

{
    public class FormulariosModel
    {


        internal DBConnector Database { get; set; }
        public FormulariosModel() { }

        internal FormulariosModel(DBConnector db)
        {
            Database = db;
        }

        public async Task InsertFormularioFS(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, FSInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";

            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            //var stream = File.Open(@IMG, FileMode.Open);
            //var task = new FirebaseStorage("sersa2020proyecto.appspot.com");

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@tipo_formulario", 1);
            await cmd.ExecuteNonQueryAsync();

        }

        public async Task InsertFormularioFN(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, FNInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";

            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@tipo_formulario", 2);
            await cmd.ExecuteNonQueryAsync();

        }

        public async Task InsertFormularioP(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, PInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";

            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@tipo_formulario", 3);
            await cmd.ExecuteNonQueryAsync();

        }


        public async Task InsertFormularioA(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, AInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";

            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@tipo_formulario", 4);
            await cmd.ExecuteNonQueryAsync();

        }


        public async Task InsertFormularioC(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, CInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";

            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@tipo_formulario", 5);
            await cmd.ExecuteNonQueryAsync();

        }

        public async Task InsertFormularioD(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, DInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";
 
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@tipo_formulario", 6);
            await cmd.ExecuteNonQueryAsync();

        }

        public async Task InsertFormularioQ(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, QInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";

            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@tipo_formulario", 7);
            await cmd.ExecuteNonQueryAsync();

        }

        public async Task InsertFormularioCl(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, ClInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@tipo_formulario", 8);
            await cmd.ExecuteNonQueryAsync();

        }

        public async Task InsertFormularioPP(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, PPInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@tipo_formulario", 9);
            await cmd.ExecuteNonQueryAsync();

        }


        public List<Formularios> llenarTablaListaFS()
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='1'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Formularios> lista = new List<Formularios>();

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    Formularios temp = new Formularios();
                    string col1Value = rdr[0].ToString();
                    temp.id = col1Value;
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    temp.Fecha = colDateTime.ToString("dd/MM/yyyy");
                    string col3Value = rdr[2].ToString();
                    temp.Acueducto = col3Value;
                    lista.Add(temp);
                }
                rdr.NextResult();
            }

            return lista;

        }

        public List<Formularios> llenarTablaListaFN()
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='2'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Formularios> lista = new List<Formularios>();

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    Formularios temp = new Formularios();
                    string col1Value = rdr[0].ToString();
                    temp.id = col1Value;
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    temp.Fecha = colDateTime.ToString("dd/MM/yyyy");
                    string col3Value = rdr[2].ToString();
                    temp.Acueducto = col3Value;
                    lista.Add(temp);
                }
                rdr.NextResult();
            }

            return lista;

        }

        public List<Formularios> llenarTablaListaP()
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='3'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Formularios> lista = new List<Formularios>();

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    Formularios temp = new Formularios();
                    string col1Value = rdr[0].ToString();
                    temp.id = col1Value;
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    temp.Fecha = colDateTime.ToString("dd/MM/yyyy");
                    string col3Value = rdr[2].ToString();
                    temp.Acueducto = col3Value;
                    lista.Add(temp);
                }
                rdr.NextResult();
            }

            return lista;

        }

        public List<Formularios> llenarTablaListaA()
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='4'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Formularios> lista = new List<Formularios>();

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    Formularios temp = new Formularios();
                    string col1Value = rdr[0].ToString();
                    temp.id = col1Value;
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    temp.Fecha = colDateTime.ToString("dd/MM/yyyy");
                    string col3Value = rdr[2].ToString();
                    temp.Acueducto = col3Value;
                    lista.Add(temp);
                }
                rdr.NextResult();
            }

            return lista;

        }

        public List<Formularios> llenarTablaListaC()
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='5'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Formularios> lista = new List<Formularios>();

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    Formularios temp = new Formularios();
                    string col1Value = rdr[0].ToString();
                    temp.id = col1Value;
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    temp.Fecha = colDateTime.ToString("dd/MM/yyyy");
                    string col3Value = rdr[2].ToString();
                    temp.Acueducto = col3Value;
                    lista.Add(temp);
                }
                rdr.NextResult();
            }

            return lista;

        }

        public List<Formularios> llenarTablaListaD()
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='6'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Formularios> lista = new List<Formularios>();

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    Formularios temp = new Formularios();
                    string col1Value = rdr[0].ToString();
                    temp.id = col1Value;
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    temp.Fecha = colDateTime.ToString("dd/MM/yyyy");
                    string col3Value = rdr[2].ToString();
                    temp.Acueducto = col3Value;
                    lista.Add(temp);
                }
                rdr.NextResult();
            }

            return lista;

        }

        public List<Formularios> llenarTablaListaQ()
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='7'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Formularios> lista = new List<Formularios>();

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    Formularios temp = new Formularios();
                    string col1Value = rdr[0].ToString();
                    temp.id = col1Value;
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    temp.Fecha = colDateTime.ToString("dd/MM/yyyy");
                    string col3Value = rdr[2].ToString();
                    temp.Acueducto = col3Value;
                    lista.Add(temp);
                }
                rdr.NextResult();
            }

            return lista;

        }

        public List<Formularios> llenarTablaListaCl()
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='8'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Formularios> lista = new List<Formularios>();

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    Formularios temp = new Formularios();
                    string col1Value = rdr[0].ToString();
                    temp.id = col1Value;
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    temp.Fecha = colDateTime.ToString("dd/MM/yyyy");
                    string col3Value = rdr[2].ToString();
                    temp.Acueducto = col3Value;
                    lista.Add(temp);
                }
                rdr.NextResult();
            }

            return lista;

        }

        public List<Formularios> llenarTablaListaPP()
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='9'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Formularios> lista = new List<Formularios>();

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    Formularios temp = new Formularios();
                    string col1Value = rdr[0].ToString();
                    temp.id = col1Value;
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    temp.Fecha = colDateTime.ToString("dd/MM/yyyy");
                    string col3Value = rdr[2].ToString();
                    temp.Acueducto = col3Value;
                    lista.Add(temp);
                }
                rdr.NextResult();
            }

            return lista;

        }

        public string obtenerFormularioFS(string ID)
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT * FROM Formulario WHERE tipo_formulario='1' and id = '" + ID + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "";

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    string col1Value = rdr[0].ToString();
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    col2Value = colDateTime.ToString("yyyy/MM/dd");
                    col2Value = col2Value.Replace("/", "-");
                    string col3Value = rdr[2].ToString();
                    string col4Value = rdr[3].ToString();
                    string col5Value = rdr[4].ToString();
                    string col6Value = rdr[5].ToString();
                    string col7Value = rdr[6].ToString();
                    string col8Value = rdr[7].ToString();
                    var info = JsonSerializer.Deserialize<FSInfoGeneral>(col8Value);
                    string col9Value = rdr[8].ToString();
                    var preguntas = JsonSerializer.Deserialize<FormularioRespuesta>(col9Value);
                    string col10Value = rdr[9].ToString();
                    string col11Value = rdr[10].ToString();
                    string col12Value = rdr[11].ToString();
                    string col13Value = rdr[12].ToString();

                    resultado += col1Value + "," + col2Value + "," + col3Value + "," + col4Value + "," + col5Value + "," + col6Value + "," + col7Value + "," +
                        info.Especificacion + "," + info.Direccion + "," + info.Limpieza + "," + info.Registro + "," + info.Toma + "," +
                        preguntas.P1 + "," + preguntas.P2 + "," + preguntas.P3 + "," + preguntas.P4 + "," + preguntas.P5 + "," + preguntas.P6 + "," +
                        preguntas.P7 + "," + preguntas.P8 + "," + preguntas.P9 + "," + preguntas.P10 + "," + col10Value + "," + col11Value + "," + col12Value + "," + col13Value;
                }
                rdr.NextResult();
            }

            return resultado;

        }

        public async Task UpdateFormularioFS(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, FSInfoGeneral ig, string NOTAS, string ID)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@id", ID);
            await cmd.ExecuteNonQueryAsync();

        }

        public string obtenerFormularioFN(string ID)
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT * FROM Formulario WHERE tipo_formulario='2' and id = '" + ID + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "";

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    string col1Value = rdr[0].ToString();
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    col2Value = colDateTime.ToString("yyyy/MM/dd");
                    string col3Value = rdr[2].ToString();
                    string col4Value = rdr[3].ToString();
                    string col5Value = rdr[4].ToString();
                    string col6Value = rdr[5].ToString();
                    string col7Value = rdr[6].ToString();
                    string col8Value = rdr[7].ToString();
                    var info = JsonSerializer.Deserialize<FNInfoGeneral>(col8Value);
                    string col9Value = rdr[8].ToString();
                    var preguntas = JsonSerializer.Deserialize<FormularioRespuesta>(col9Value);
                    string col10Value = rdr[9].ToString();
                    string col11Value = rdr[10].ToString();
                    string col12Value = rdr[11].ToString();
                    string col13Value = rdr[12].ToString();

                    resultado += col1Value + "," + col2Value + "," + col3Value + "," + col4Value + "," + col5Value + "," + col6Value + "," + col7Value + "," +
                        info.Naciente + "," + info.Registro + "," + info.Captacion + "," + info.Direccion + ","+
                        preguntas.P1 + "," + preguntas.P2 + "," + preguntas.P3 + "," + preguntas.P4 + "," + preguntas.P5 + "," + preguntas.P6 + "," +
                        preguntas.P7 + "," + preguntas.P8 + "," + preguntas.P9 + "," + preguntas.P10 + "," + col10Value + "," + col11Value + "," + col12Value + "," + col13Value;
                }
                rdr.NextResult();
            }

            return resultado;

        }

        public async Task UpdateFormularioFN(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, FNInfoGeneral ig, string NOTAS, string ID)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@id", ID);
            await cmd.ExecuteNonQueryAsync();

        }

        public string obtenerFormularioP(string ID)
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT * FROM Formulario WHERE tipo_formulario='3' and id = '" + ID + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "";

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    string col1Value = rdr[0].ToString();
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    col2Value = colDateTime.ToString("yyyy/MM/dd");
                    string col3Value = rdr[2].ToString();
                    string col4Value = rdr[3].ToString();
                    string col5Value = rdr[4].ToString();
                    string col6Value = rdr[5].ToString();
                    string col7Value = rdr[6].ToString();
                    string col8Value = rdr[7].ToString();
                    var info = JsonSerializer.Deserialize<PInfoGeneral>(col8Value);
                    string col9Value = rdr[8].ToString();
                    var preguntas = JsonSerializer.Deserialize<FormularioRespuesta>(col9Value);
                    string col10Value = rdr[9].ToString();
                    string col11Value = rdr[10].ToString();
                    string col12Value = rdr[11].ToString();
                    string col13Value = rdr[12].ToString();

                    resultado += col1Value + "," + col2Value + "," + col3Value + "," + col4Value + "," + col5Value + "," + col6Value + "," + col7Value + "," +
                        info.Pozo + "," + info.TIPOP + "," + info.Senasa + "," + info.ESPESOR + "," + info.DIAMETRO + "," + info.DINAMICO + "," + info.FRIATICO + "," + info.Registro + "," +
                        preguntas.P1 + "," + preguntas.P2 + "," + preguntas.P3 + "," + preguntas.P4 + "," + preguntas.P5 + "," + preguntas.P6 + "," +
                        preguntas.P7 + "," + preguntas.P8 + "," + preguntas.P9 + "," + preguntas.P10 + "," + col10Value + "," + col11Value + "," + col12Value + "," + col13Value;
                }
                rdr.NextResult();
            }

            return resultado;

        }

        public async Task UpdateFormularioP(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, PInfoGeneral ig, string NOTAS, string ID)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@id", ID);
            await cmd.ExecuteNonQueryAsync();

        }

        public string obtenerFormularioA(string ID)
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT * FROM Formulario WHERE tipo_formulario='4' and id = '" + ID + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "";

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    string col1Value = rdr[0].ToString();
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    col2Value = colDateTime.ToString("yyyy/MM/dd");
                    string col3Value = rdr[2].ToString();
                    string col4Value = rdr[3].ToString();
                    string col5Value = rdr[4].ToString();
                    string col6Value = rdr[5].ToString();
                    string col7Value = rdr[6].ToString();
                    string col8Value = rdr[7].ToString();
                    var info = JsonSerializer.Deserialize<AInfoGeneral>(col8Value);
                    string col9Value = rdr[8].ToString();
                    var preguntas = JsonSerializer.Deserialize<FormularioRespuesta>(col9Value);
                    string col10Value = rdr[9].ToString();
                    string col11Value = rdr[10].ToString();
                    string col12Value = rdr[11].ToString();
                    string col13Value = rdr[12].ToString();

                    resultado += col1Value + "," + col2Value + "," + col3Value + "," + col4Value + "," + col5Value + "," + col6Value + "," + col7Value + "," +
                        info.Tanque + "," + info.Limpieza + "," + info.Registro + "," + info.MatTanque + "," + info.TipoTanque  + "," +
                        preguntas.P1 + "," + preguntas.P2 + "," + preguntas.P3 + "," + preguntas.P4 + "," + preguntas.P5 + "," + preguntas.P6 + "," +
                        preguntas.P7 + "," + preguntas.P8 + "," + preguntas.P9 + "," + preguntas.P10 + "," + col10Value + "," + col11Value + "," + col12Value + "," + col13Value;
                }
                rdr.NextResult();
            }

            return resultado;

        }

        public async Task UpdateFormularioA(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, AInfoGeneral ig, string NOTAS, string ID)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@id", ID);
            await cmd.ExecuteNonQueryAsync();

        }


        public string obtenerFormularioC(string ID)
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT * FROM Formulario WHERE tipo_formulario='5' and id = '" + ID + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "";

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    string col1Value = rdr[0].ToString();
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    col2Value = colDateTime.ToString("yyyy/MM/dd");
                    string col3Value = rdr[2].ToString();
                    string col4Value = rdr[3].ToString();
                    string col5Value = rdr[4].ToString();
                    string col6Value = rdr[5].ToString();
                    string col7Value = rdr[6].ToString();
                    string col8Value = rdr[7].ToString();
                    var info = JsonSerializer.Deserialize<CInfoGeneral>(col8Value);
                    string col9Value = rdr[8].ToString();
                    var preguntas = JsonSerializer.Deserialize<FormularioRespuesta>(col9Value);
                    string col10Value = rdr[9].ToString();
                    string col11Value = rdr[10].ToString();
                    string col12Value = rdr[11].ToString();
                    string col13Value = rdr[12].ToString();

                    resultado += col1Value + "," + col2Value + "," + col3Value + "," + col4Value + "," + col5Value + "," + col6Value + "," + col7Value + "," +
                        info.MatTuberia + "," + info.Reparaciones + "," + info.ConduccionTanque + "," + info.FechaConstruccion + "," +
                        preguntas.P1 + "," + preguntas.P2 + "," + preguntas.P3 + "," + preguntas.P4 + "," + preguntas.P5 + "," + preguntas.P6 + "," +
                        preguntas.P7 + "," + preguntas.P8 + "," + preguntas.P9 + "," + preguntas.P10 + "," + col10Value + "," + col11Value + "," + col12Value + "," + col13Value;
                }
                rdr.NextResult();
            }

            return resultado;

        }

        public async Task UpdateFormularioC(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, CInfoGeneral ig, string NOTAS, string ID)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@id", ID);
            await cmd.ExecuteNonQueryAsync();

        }

        public string obtenerFormularioD(string ID)
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT * FROM Formulario WHERE tipo_formulario='6' and id = '" + ID + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "";

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    string col1Value = rdr[0].ToString();
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    col2Value = colDateTime.ToString("yyyy/MM/dd");
                    string col3Value = rdr[2].ToString();
                    string col4Value = rdr[3].ToString();
                    string col5Value = rdr[4].ToString();
                    string col6Value = rdr[5].ToString();
                    string col7Value = rdr[6].ToString();
                    string col8Value = rdr[7].ToString();
                    var info = JsonSerializer.Deserialize<DInfoGeneral>(col8Value);
                    string col9Value = rdr[8].ToString();
                    var preguntas = JsonSerializer.Deserialize<FormularioRespuesta>(col9Value);
                    string col10Value = rdr[9].ToString();
                    string col11Value = rdr[10].ToString();
                    string col12Value = rdr[11].ToString();
                    string col13Value = rdr[12].ToString();

                    resultado += col1Value + "," + col2Value + "," + col3Value + "," + col4Value + "," + col5Value + "," + col6Value + "," + col7Value + "," +
                        info.MatTuberia + "," + info.Reparaciones + "," + info.FechaConstruccion + "," + 
                        preguntas.P1 + "," + preguntas.P2 + "," + preguntas.P3 + "," + preguntas.P4 + "," + preguntas.P5 + "," + preguntas.P6 + "," +
                        preguntas.P7 + "," + preguntas.P8 + "," + preguntas.P9 + "," + preguntas.P10 + "," + col10Value + "," + col11Value + "," + col12Value + "," + col13Value;
                }
                rdr.NextResult();
            }

            return resultado;

        }

        public async Task UpdateFormularioD(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, DInfoGeneral ig, string NOTAS, string ID)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@id", ID);
            await cmd.ExecuteNonQueryAsync();

        }

        public string obtenerFormularioQ(string ID)
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT * FROM Formulario WHERE tipo_formulario='7' and id = '" + ID + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "";

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    string col1Value = rdr[0].ToString();
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    col2Value = colDateTime.ToString("yyyy/MM/dd");
                    string col3Value = rdr[2].ToString();
                    string col4Value = rdr[3].ToString();
                    string col5Value = rdr[4].ToString();
                    string col6Value = rdr[5].ToString();
                    string col7Value = rdr[6].ToString();
                    string col8Value = rdr[7].ToString();
                    var info = JsonSerializer.Deserialize<QInfoGeneral>(col8Value);
                    string col9Value = rdr[8].ToString();
                    var preguntas = JsonSerializer.Deserialize<FormularioRespuesta>(col9Value);
                    string col10Value = rdr[9].ToString();
                    string col11Value = rdr[10].ToString();
                    string col12Value = rdr[11].ToString();
                    string col13Value = rdr[12].ToString();

                    resultado += col1Value + "," + col2Value + "," + col3Value + "," + col4Value + "," + col5Value + "," + col6Value + "," + col7Value + "," +
                        info.Limpieza + "," + info.MatTuberia + "," + info.FechaConstruccion + "," + 
                        preguntas.P1 + "," + preguntas.P2 + "," + preguntas.P3 + "," + preguntas.P4 + "," + preguntas.P5 + "," + preguntas.P6 + "," +
                        preguntas.P7 + "," + preguntas.P8 + "," + preguntas.P9 + "," + preguntas.P10 + "," + col10Value + "," + col11Value + "," + col12Value + "," + col13Value;
                }
                rdr.NextResult();
            }

            return resultado;

        }

        public async Task UpdateFormularioQ(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, QInfoGeneral ig, string NOTAS, string ID)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@id", ID);
            await cmd.ExecuteNonQueryAsync();

        }

        public string obtenerFormularioCl(string ID)
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT * FROM Formulario WHERE tipo_formulario='8' and id = '" + ID + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "";

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    string col1Value = rdr[0].ToString();
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    col2Value = colDateTime.ToString("yyyy/MM/dd");
                    string col3Value = rdr[2].ToString();
                    string col4Value = rdr[3].ToString();
                    string col5Value = rdr[4].ToString();
                    string col6Value = rdr[5].ToString();
                    string col7Value = rdr[6].ToString();
                    string col8Value = rdr[7].ToString();
                    var info = JsonSerializer.Deserialize<ClInfoGeneral>(col8Value);
                    string col9Value = rdr[8].ToString();
                    var preguntas = JsonSerializer.Deserialize<FormularioRespuesta>(col9Value);
                    string col10Value = rdr[9].ToString();
                    string col11Value = rdr[10].ToString();
                    string col12Value = rdr[11].ToString();
                    string col13Value = rdr[12].ToString();

                    resultado += col1Value + "," + col2Value + "," + col3Value + "," + col4Value + "," + col5Value + "," + col6Value + "," + col7Value + "," +
                        info.TipoSistema + "," + info.FechaInstalacion + "," + info.TipoDosificacion + "," + info.FechaConstruccion + "," + 
                        preguntas.P1 + "," + preguntas.P2 + "," + preguntas.P3 + "," + preguntas.P4 + "," + preguntas.P5 + "," + preguntas.P6 + "," +
                        preguntas.P7 + "," + preguntas.P8 + "," + preguntas.P9 + "," + preguntas.P10 + "," + col10Value + "," + col11Value + "," + col12Value + "," + col13Value;
                }
                rdr.NextResult();
            }

            return resultado;

        }

        public async Task UpdateFormularioCl(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, ClInfoGeneral ig, string NOTAS, string ID)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@id", ID);
            await cmd.ExecuteNonQueryAsync();

        }

        public string obtenerFormularioPP(string ID)
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT * FROM Formulario WHERE tipo_formulario='9' and id = '" + ID + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "";

            while (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    string col1Value = rdr[0].ToString();
                    string col2Value = rdr[1].ToString();
                    double col2Double = Double.Parse(col2Value);
                    System.DateTime colDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    colDateTime = colDateTime.AddSeconds(col2Double).ToLocalTime();
                    col2Value = colDateTime.ToString("yyyy/MM/dd");
                    string col3Value = rdr[2].ToString();
                    string col4Value = rdr[3].ToString();
                    string col5Value = rdr[4].ToString();
                    string col6Value = rdr[5].ToString();
                    string col7Value = rdr[6].ToString();
                    string col8Value = rdr[7].ToString();
                    var info = JsonSerializer.Deserialize<PPInfoGeneral>(col8Value);
                    string col9Value = rdr[8].ToString();
                    var preguntas = JsonSerializer.Deserialize<FormularioRespuesta>(col9Value);
                    string col10Value = rdr[9].ToString();
                    string col11Value = rdr[10].ToString();
                    string col12Value = rdr[11].ToString();
                    string col13Value = rdr[12].ToString();

                    resultado += col1Value + "," + col2Value + "," + col3Value + "," + col4Value + "," + col5Value + "," + col6Value + "," + col7Value + "," +
                        info.SistemaPot + "," + info.Especifique + "," + info.FechaConstruccion + "," + 
                        preguntas.P1 + "," + preguntas.P2 + "," + preguntas.P3 + "," + preguntas.P4 + "," + preguntas.P5 + "," + preguntas.P6 + "," +
                        preguntas.P7 + "," + preguntas.P8 + "," + preguntas.P9 + "," + preguntas.P10 + "," + col10Value + "," + col11Value + "," + col12Value + "," + col13Value;
                }
                rdr.NextResult();
            }

            return resultado;

        }

        public async Task UpdateFormularioPP(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, PPInfoGeneral ig, string NOTAS, string ID)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@id", ID);
            await cmd.ExecuteNonQueryAsync();

        }

        public string eliminarFormulario(string ID)
        {
            string connStr = "server=35.202.203.47;port=3306;database=sersa;user=root;password=asada2020;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "DELETE FROM Formulario WHERE id = '" + ID + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            string resultado = "";
            return resultado;

        }

    }
    
}
