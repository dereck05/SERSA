using System;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace Sersa

{
    public class FSInfoGeneral
    {
        public string Limpieza { get; set; }
        public string Especificacion { get; set; }
        public string Toma { get; set; }
        public string Registro { get; set; }
        public string Direccion { get; set; }


    }

    
}
