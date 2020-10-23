using System;
using MySqlConnector;

namespace Sersa.Models
 

{
    public class DBIrsassConnector : IDisposable
    {
        public MySqlConnection Connection { get; }

        public DBIrsassConnector(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}

