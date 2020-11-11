using System;
namespace Sersa.Models
{
    public class InformeResponse
    {
        public string fecha { get; set; }
        public string acueducto { get; set; }
        public string encargado { get; set; }
        public string info_general { get; set; }
        public string infraestructura { get; set; }
        public string comentarios { get; set; }
        public string imagen { get; set; }
        public string tipo { get; set; }
        public int si { get; set; }
        public int no { get; set; }
        public string riesgo { get; set; }

        public InformeResponse(){}
    }
}
