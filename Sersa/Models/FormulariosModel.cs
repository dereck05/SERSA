using System;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Sersa.Models;
using System.Collections.Generic;

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

        public async Task InsertFormularioFS(string FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, FSInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

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
            cmd.Parameters.AddWithValue("@tipo_formulario", 1);
            await cmd.ExecuteNonQueryAsync();

        }

        public async Task InsertFormularioFN(string FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, FNInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

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

        public async Task InsertFormularioP(string FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, PInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

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


        public async Task InsertFormularioA(string FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, AInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

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


        public async Task InsertFormularioC(string FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, CInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

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

        public async Task InsertFormularioD(string FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, DInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

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

        public async Task InsertFormularioQ(string FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, QInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

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

        public async Task InsertFormularioCl(string FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, ClInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

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

        public async Task InsertFormularioPP(string FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, PPInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

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

    }
    
}
