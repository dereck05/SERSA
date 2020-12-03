using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace Sersa.Models

{
    public class LoginModel
    {
        List<Usuario> posts;
        internal DBIrsassConnector Database { get; set; }
        public LoginModel() { }


        internal LoginModel(DBIrsassConnector db)
        {
            Database = db;
        }
        public IConfigurationRoot GetConnection()

        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();

            return builder;

        }
        public List<Usuario> credentialsValidate(string user, string password) {
            //Conexion escondida
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Irsass").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();

            string sql = "SELECT * FROM USUARIO WHERE USUARIO=@user and Contrasenna=@password";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@password", password);
            List<Usuario> usuarios = ReadAllAsync(cmd.ExecuteReader());
            return usuarios;
        }

        public async Task<List<Usuario>> GetUsers()
        {
            //Conexion escondida
            var connection = GetConnection().GetSection("ConnectionStrings").GetSection("Irsass").Value;
            MySqlConnection conn = new MySqlConnection(connection);
            string sql  = "SELECT id FROM USUARIO";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            return ReadAllAsync(cmd.ExecuteReader());

        }
        public string[] GetAsadas() {
            int idAsada = posts[0].id;
            //Conexion escondida
            var connection1 = GetConnection().GetSection("ConnectionStrings").GetSection("Irsass").Value;
            MySqlConnection conn1 = new MySqlConnection(connection1);
            conn1.Open();
            string sql1  = "SELECT * FROM USUARIOXASADA WHERE USUARIO_ID=@id";
            MySqlCommand cmd1 = new MySqlCommand(sql1, conn1);
            cmd1.Parameters.AddWithValue("@id", idAsada);
            return ReadAllAsyncAsada(cmd1.ExecuteReader());
        }
        private string[] ReadAllAsyncAsada(MySqlDataReader reader)
        {
            string[] asadas = new string[10];
            
            int cont = 0;
            while (reader.HasRows)
            {

                while (reader.Read())
                {
                    asadas[cont + 1] = reader[1].ToString();
                    Autenticacion.set_idAsada(asadas[cont + 1]);
                }
                reader.NextResult();
            }



            
            return asadas;
        }
        private List<Usuario> ReadAllAsync(MySqlDataReader reader)
        {
            posts = new List<Usuario>();
            
            
            while (reader.HasRows)
            {

                while (reader.Read())
                {
                    Usuario temp = new Usuario();
                    int id = Int32.Parse(reader[0].ToString());
                    temp.id = id;
                    int tipo = Int32.Parse(reader[4].ToString());
                    temp.tipo = tipo;
                    
                    posts.Add(temp);
                }
                reader.NextResult();
            }
            try
            {
                Autenticacion.set_idUsuario(posts[0].id);
                Autenticacion.set_tipo(posts[0].tipo);
            }
            catch (Exception e) {
                return new List<Usuario>();
            }
            return posts;
        }
    }
}
