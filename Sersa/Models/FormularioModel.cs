using System;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;
using System.Text.Json;
using Newtonsoft.Json.Linq;

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
        public class DateOfBirth
        {
            public int year { get; set; }
            public int month { get; set; }
            public int day { get; set; }
            public DateOfBirth(int a, int b, int c)
            {
                year = a;
                month = b;
                day = c;
            }


        }

        public async Task InsertAsync()
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", "a");
            cmd.Parameters.AddWithValue("@encargado", "e");
            cmd.Parameters.AddWithValue("@telefono", "t");
            cmd.Parameters.AddWithValue("@funcionario", "f");
            DateOfBirth d = new DateOfBirth(1, 2, 3);
            var json = JsonSerializer.Serialize(d);
            Console.WriteLine(json);
            cmd.Parameters.AddWithValue("@info_general",json);
            cmd.Parameters.AddWithValue("@infraestructura", json);
            cmd.Parameters.AddWithValue("@imagen", "a");
            cmd.Parameters.AddWithValue("@latitud", "e");
            cmd.Parameters.AddWithValue("@longitud", "t");
            cmd.Parameters.AddWithValue("@comentarios", "f");
            await cmd.ExecuteNonQueryAsync();


        }
    }

    
}
