using System;
namespace Sersa.Models
{
    public class Usuario
    {
        public int id;
        public int tipo;

        internal DBIrsassConnector Database { get; set; }
        public Usuario(int pid, int type)
        {
            id = pid;
            tipo = type;
        }
        public Usuario(DBIrsassConnector db)
        {
            Database = db;
        }
    }
}
