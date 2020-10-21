using System;
using MySqlConnector;

namespace Sersa
{
    public class DBConnector : IDisposable
    {
        public MySqlConnection Connection { get; }

        public DBConnector(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}