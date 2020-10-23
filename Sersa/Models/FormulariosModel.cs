using System;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Sersa.Models;

namespace Sersa

{
    public class FormulariosModel
    {


        internal DBConnector Database { get; set; }
        public FormulariosModel() { }

        internal FormulariosModel(DBConnector db)
        {
            Database = db;
        }

        public async Task InsertFormularioFS(string FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, FSInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@tipo_formulario", 1);
            await cmd.ExecuteNonQueryAsync();

        }

        public async Task InsertFormularioFN(string FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, FNInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@tipo_formulario", "FN");
            await cmd.ExecuteNonQueryAsync();

        }

        public async Task InsertFormularioP(string FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, FormularioRespuesta f, PInfoGeneral ig, string NOTAS)
        {
            using var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `Formulario` (`fecha`, `usuario`, `acueducto`, `encargado`, `telefono`, `funcionario`, `info_general`, `infraestructura`, `imagen`,`latitud`,`longitud`,`comentarios`,`tipo_formulario`) values (@fecha, @usuario, @acueducto, @encargado, @telefono, @funcionario, @info_general, @infraestructura,@imagen,@latitud,@longitud,@comentarios,@tipo_formulario)";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            cmd.Parameters.AddWithValue("@fecha", timestamp);
            cmd.Parameters.AddWithValue("@usuario", "testuser");
            cmd.Parameters.AddWithValue("@acueducto", ACUEDUCTO);
            cmd.Parameters.AddWithValue("@encargado", ENCARGADO);
            cmd.Parameters.AddWithValue("@telefono", TELEFONO);
            cmd.Parameters.AddWithValue("@funcionario", FUNCIONARIO);
            var jsonIG = JsonSerializer.Serialize(ig);
            var jsonIF = JsonSerializer.Serialize(f);

            cmd.Parameters.AddWithValue("@info_general", jsonIG);
            cmd.Parameters.AddWithValue("@infraestructura", jsonIF);
            cmd.Parameters.AddWithValue("@imagen", IMG);
            cmd.Parameters.AddWithValue("@latitud", LATITUD);
            cmd.Parameters.AddWithValue("@longitud", LONGITUD);
            cmd.Parameters.AddWithValue("@comentarios", NOTAS);
            cmd.Parameters.AddWithValue("@tipo_formulario", "P");
            await cmd.ExecuteNonQueryAsync();

        }

    }



    
}
