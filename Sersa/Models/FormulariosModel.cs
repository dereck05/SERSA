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
using Microsoft.AspNetCore.Hosting;
using Firebase.Auth;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

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

        public IConfigurationRoot GetConnection()

        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();

            return builder;

        }

        public void InsertFormularioFS(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, FSInfoGeneral ig, string NOTAS)
        {
            string asada = Autenticacion.get_idAsada();
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "INSERT INTO Formulario ( fecha ,  usuario ,  acueducto ,  encargado ,  telefono ,  funcionario ,  info_general ,  infraestructura ,  imagen , latitud , longitud , comentarios , tipo_formulario , asada ) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario,@asada)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.Parameters.AddWithValue("@asada", asada);
            cmd.ExecuteReader();

        }

        public void InsertFormularioFN(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, FNInfoGeneral ig, string NOTAS)
        {
            string asada = Autenticacion.get_idAsada();
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "INSERT INTO Formulario ( fecha ,  usuario ,  acueducto ,  encargado ,  telefono ,  funcionario ,  info_general ,  infraestructura ,  imagen , latitud , longitud , comentarios , tipo_formulario , asada ) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario,@asada)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.Parameters.AddWithValue("@tipo_formulario", 2);
            cmd.Parameters.AddWithValue("@asada", asada);
            cmd.ExecuteReader();

        }

        public void InsertFormularioP(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, PInfoGeneral ig, string NOTAS)
        {
            string asada = Autenticacion.get_idAsada();
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "INSERT INTO Formulario ( fecha ,  usuario ,  acueducto ,  encargado ,  telefono ,  funcionario ,  info_general ,  infraestructura ,  imagen , latitud , longitud , comentarios , tipo_formulario , asada ) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario,@asada)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.Parameters.AddWithValue("@tipo_formulario", 3);
            cmd.Parameters.AddWithValue("@asada", asada);
            cmd.ExecuteReader();

        }


        public void InsertFormularioA(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, AInfoGeneral ig, string NOTAS)
        {
            string asada = Autenticacion.get_idAsada();
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "INSERT INTO Formulario ( fecha ,  usuario ,  acueducto ,  encargado ,  telefono ,  funcionario ,  info_general ,  infraestructura ,  imagen , latitud , longitud , comentarios , tipo_formulario , asada ) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario,@asada)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.Parameters.AddWithValue("@tipo_formulario", 4);
            cmd.Parameters.AddWithValue("@asada", asada);
            cmd.ExecuteReader();

        }


        public void InsertFormularioC(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, CInfoGeneral ig, string NOTAS)
        {
            string asada = Autenticacion.get_idAsada();
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "INSERT INTO Formulario ( fecha ,  usuario ,  acueducto ,  encargado ,  telefono ,  funcionario ,  info_general ,  infraestructura ,  imagen , latitud , longitud , comentarios , tipo_formulario , asada ) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario,@asada)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.Parameters.AddWithValue("@tipo_formulario", 5);
            cmd.Parameters.AddWithValue("@asada", asada);
            cmd.ExecuteReader();

        }

        public void InsertFormularioD(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, DInfoGeneral ig, string NOTAS)
        {
            string asada = Autenticacion.get_idAsada();
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "INSERT INTO Formulario ( fecha ,  usuario ,  acueducto ,  encargado ,  telefono ,  funcionario ,  info_general ,  infraestructura ,  imagen , latitud , longitud , comentarios , tipo_formulario , asada ) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario,@asada)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.Parameters.AddWithValue("@tipo_formulario", 6);
            cmd.Parameters.AddWithValue("@asada", asada);
            cmd.ExecuteReader();

        }

        public void InsertFormularioQ(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, QInfoGeneral ig, string NOTAS)
        {
            string asada = Autenticacion.get_idAsada();
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "INSERT INTO Formulario ( fecha ,  usuario ,  acueducto ,  encargado ,  telefono ,  funcionario ,  info_general ,  infraestructura ,  imagen , latitud , longitud , comentarios , tipo_formulario , asada ) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario,@asada)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.Parameters.AddWithValue("@tipo_formulario", 7);
            cmd.Parameters.AddWithValue("@asada", asada);
            cmd.ExecuteReader();

        }

        public void InsertFormularioCl(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, ClInfoGeneral ig, string NOTAS)
        {
            string asada = Autenticacion.get_idAsada();
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "INSERT INTO Formulario ( fecha ,  usuario ,  acueducto ,  encargado ,  telefono ,  funcionario ,  info_general ,  infraestructura ,  imagen , latitud , longitud , comentarios , tipo_formulario , asada ) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario,@asada)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.Parameters.AddWithValue("@tipo_formulario", 8);
            cmd.Parameters.AddWithValue("@asada", asada);
            cmd.ExecuteReader();

        }

        public void InsertFormularioPP(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, PPInfoGeneral ig, string NOTAS)
        {
            string asada = Autenticacion.get_idAsada();
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "INSERT INTO Formulario ( fecha ,  usuario ,  acueducto ,  encargado ,  telefono ,  funcionario ,  info_general ,  infraestructura ,  imagen , latitud , longitud , comentarios , tipo_formulario , asada ) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario,@asada)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.Parameters.AddWithValue("@tipo_formulario", 9);
            cmd.Parameters.AddWithValue("@asada", asada);
            cmd.ExecuteReader();

        }


        public List<Formularios> llenarTablaListaFS()
        {
            int tipoUsuario = Autenticacion.get_tipo();
            string idAsada = Autenticacion.get_idAsada();
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "";
            if (tipoUsuario == 1)
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='1'";
            }
            else
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='1' and asada = '" + idAsada + "'";
            }
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
            int tipoUsuario = Autenticacion.get_tipo();
            string idAsada = Autenticacion.get_idAsada();
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "";
            if (tipoUsuario == 1)
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='2'";
            }
            else
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='2' and asada = '" + idAsada + "'";
            }
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
            int tipoUsuario = Autenticacion.get_tipo();
            string idAsada = Autenticacion.get_idAsada();
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "";
            if (tipoUsuario == 1)
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='3'";
            }
            else
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='3' and asada = '" + idAsada + "'";
            }
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
            int tipoUsuario = Autenticacion.get_tipo();
            string idAsada = Autenticacion.get_idAsada();
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "";
            if (tipoUsuario == 1)
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='4'";
            }
            else
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='4' and asada = '" + idAsada + "'";
            }
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
            int tipoUsuario = Autenticacion.get_tipo();
            string idAsada = Autenticacion.get_idAsada();
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "";
            if (tipoUsuario == 1)
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='5'";
            }
            else
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='5' and asada = '" + idAsada + "'";
            }
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
            int tipoUsuario = Autenticacion.get_tipo();
            string idAsada = Autenticacion.get_idAsada();
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "";
            if (tipoUsuario == 1)
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='6'";
            }
            else
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='6' and asada = '" + idAsada + "'";
            }
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
            int tipoUsuario = Autenticacion.get_tipo();
            string idAsada = Autenticacion.get_idAsada();
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "";
            if (tipoUsuario == 1)
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='7'";
            }
            else
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='7' and asada = '" + idAsada + "'";
            }
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
            int tipoUsuario = Autenticacion.get_tipo();
            string idAsada = Autenticacion.get_idAsada();
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "";
            if (tipoUsuario == 1)
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='8'";
            }
            else
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='8' and asada = '" + idAsada + "'";
            }
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
            int tipoUsuario = Autenticacion.get_tipo();
            string idAsada = Autenticacion.get_idAsada();
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "";
            if (tipoUsuario == 1)
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='9'";
            }
            else
            {
                sql = "SELECT id, fecha,acueducto FROM Formulario WHERE tipo_formulario='9' and asada = '" + idAsada + "'";
            }
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
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
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

        public void UpdateFormularioFS(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, FSInfoGeneral ig, string NOTAS, string ID)
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.ExecuteReader();

        }

        public string obtenerFormularioFN(string ID)
        {
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
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
                    col2Value = col2Value.Replace("/", "-");
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
                        info.Naciente + "," + info.Registro + "," + info.Captacion + "," + info.Direccion + "," +
                        preguntas.P1 + "," + preguntas.P2 + "," + preguntas.P3 + "," + preguntas.P4 + "," + preguntas.P5 + "," + preguntas.P6 + "," +
                        preguntas.P7 + "," + preguntas.P8 + "," + preguntas.P9 + "," + preguntas.P10 + "," + col10Value + "," + col11Value + "," + col12Value + "," + col13Value;
                }
                rdr.NextResult();
            }

            return resultado;

        }

        public void UpdateFormularioFN(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, FNInfoGeneral ig, string NOTAS, string ID)
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.ExecuteReader();

        }

        public string obtenerFormularioP(string ID)
        {
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
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
                    col2Value = colDateTime.ToString("yyyy/MM/dd");
                    col2Value = col2Value.Replace("/", "-");
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

        public void UpdateFormularioP(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, PInfoGeneral ig, string NOTAS, string ID)
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.ExecuteReader();

        }

        public string obtenerFormularioA(string ID)
        {
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
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
                    col2Value = col2Value.Replace("/", "-");
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
                        info.Tanque + "," + info.Limpieza + "," + info.Registro + "," + info.MatTanque + "," + info.TipoTanque + "," +
                        preguntas.P1 + "," + preguntas.P2 + "," + preguntas.P3 + "," + preguntas.P4 + "," + preguntas.P5 + "," + preguntas.P6 + "," +
                        preguntas.P7 + "," + preguntas.P8 + "," + preguntas.P9 + "," + preguntas.P10 + "," + col10Value + "," + col11Value + "," + col12Value + "," + col13Value;
                }
                rdr.NextResult();
            }

            return resultado;

        }

        public void UpdateFormularioA(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, AInfoGeneral ig, string NOTAS, string ID)
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.ExecuteReader();

        }


        public string obtenerFormularioC(string ID)
        {
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
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
                    col2Value = col2Value.Replace("/", "-");
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

        public void UpdateFormularioC(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, CInfoGeneral ig, string NOTAS, string ID)
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.ExecuteReader();

        }

        public string obtenerFormularioD(string ID)
        {
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
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
                    col2Value = col2Value.Replace("/", "-");
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

        public void UpdateFormularioD(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, DInfoGeneral ig, string NOTAS, string ID)
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.ExecuteReader();

        }

        public string obtenerFormularioQ(string ID)
        {
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
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
                    col2Value = col2Value.Replace("/", "-");
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

        public void UpdateFormularioQ(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, QInfoGeneral ig, string NOTAS, string ID)
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.ExecuteReader();

        }

        public string obtenerFormularioCl(string ID)
        {
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
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
                    col2Value = col2Value.Replace("/", "-");
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

        public void UpdateFormularioCl(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, ClInfoGeneral ig, string NOTAS, string ID)
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.ExecuteReader();

        }

        public string obtenerFormularioPP(string ID)
        {
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
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
                    col2Value = col2Value.Replace("/", "-");
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

        public void UpdateFormularioPP(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, PPInfoGeneral ig, string NOTAS, string ID)
        {
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = "UPDATE Formulario SET fecha = @fecha, usuario = @usuario, acueducto = @acueducto, encargado = @encargado, telefono = @telefono, funcionario = @funcionario, info_general = @info_general, infraestructura = @infraestructura, imagen = @imagen, latitud = @latitud, longitud = @longitud, comentarios = @comentarios WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var timestamp1 = new DateTimeOffset(FECHA);
            var timestamp = timestamp1.ToUnixTimeSeconds();


            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", Autenticacion.get_idUsuario());
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
            cmd.ExecuteReader();

        }

        public string eliminarFormulario(string ID)
        {
            string connStr = GetConnection().GetSection("ConnectionStrings").GetSection("Sersa").Value;
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
