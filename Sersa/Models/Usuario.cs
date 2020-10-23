using System;
namespace Sersa.Models
{
    public class Usuario
    {
        public string nombre;
        public string password;
        public string usuario;
        public int tipo;

        internal DBIrsassConnector Database { get; set; }
        public Usuario(string nom, string user, string passw, int type)
        {
            nombre = nom;
            usuario = user;
            password = passw;
            tipo = type;
        }
        public Usuario(DBIrsassConnector db)
        {
            Database = db;
        }
    }
}
