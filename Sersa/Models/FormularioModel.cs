using System;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;

namespace Sersa

{
    public class FormularioModel
    {


        internal DBConnector Database { get; set; }
        public FormularioModel() { }

        internal FormularioModel(DBConnector db)
        {
            Database = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", "a");
            cmd.Parameters.AddWithValue("@encargado", "e");
            cmd.Parameters.AddWithValue("@telefono", "t");
            cmd.Parameters.AddWithValue("@funcionario", "f");
            await cmd.ExecuteNonQueryAsync();


        }
    }
}
