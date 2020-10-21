using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sersa.Models
{
    public class HistorialModel
    {
        internal DBConnector Database { get; set; }

        public HistorialModel() { }

        internal HistorialModel(DBConnector db)
        {
            Database = db;
        }

        public async Task InsertAsync() 
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Historial` (`nombre`, `fecha`, `url`) VALUES (@nombre, @fecha, @url)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@nombre", "nombreEj");
            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@url", "https://www.google.com/");
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
