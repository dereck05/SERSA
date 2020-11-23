using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;

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
        public async Task<List<Usuario>> credentialsValidate(string user, string password) {
            
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `USUARIO` WHERE USUARIO=@user and Contrasenna=@password";
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@password", password);
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task<List<Usuario>> GetUsers()
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id ` FROM `USUARIO`";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());

        }
        public async Task<string[]> GetAsadas() {
            int idAsada = posts[0].id;
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `USUARIOXASADA` WHERE USUARIO_ID=@id";
            cmd.Parameters.AddWithValue("@id", idAsada);
            return await ReadAllAsyncAsada(await cmd.ExecuteReaderAsync());
        }
        private async Task<string[]> ReadAllAsyncAsada(DbDataReader reader)
        {
            string[] asadas = new string[10];
            using (reader)
            {
                int cont = 0;
                while (await reader.ReadAsync())
                {
                    asadas[cont+1] = reader.GetString(1);
                    Autenticacion.set_idAsada(asadas[cont+1]);
                }
            }
            


            return asadas;
        }
        private async Task<List<Usuario>> ReadAllAsync(DbDataReader reader)
        {
            posts = new List<Usuario>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Usuario(Database)
                    {
                        id = reader.GetInt32(0),
                        tipo = reader.GetInt32(4),
                    };
                    posts.Add(post);
                }
            }
            Autenticacion.set_idUsuario(posts[0].id);
            Autenticacion.set_tipo(posts[0].tipo);
            return posts;
        }
    }
}
