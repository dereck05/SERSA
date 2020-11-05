using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace Sersa.Models

{
    public class LoginModel
    {

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
            cmd.CommandText = @"SELECT `*` FROM `USUARIO`";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());

        }
        private async Task<List<Usuario>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<Usuario>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Usuario(Database)
                    {
                        nombre = reader.GetString(1),
                        usuario = reader.GetString(2),
                        password= reader.GetString(3),
                        tipo = reader.GetInt32(4),
                    };
                    posts.Add(post);
                }
            }

            return posts;
        }
    }
}
