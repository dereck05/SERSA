using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Sersa.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sersa.Controllers
{
    public class MapaController : Controller
    {

        internal DBConnector Database { get; set; }

        public MapaController(DBConnector db)
        {
            Database = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public List<Mapa> generarPuntos(DateTime fechaInicio, DateTime fechaFin, string tipos)
        {
            List<int> listaTipos = new List<int>();
            List<string> stringsTipos = new List<string>();
            stringsTipos = tipos.Split(',').ToList<string>();

            foreach (string tipo in stringsTipos) {
                int temp = 0;
                temp = int.Parse(tipo);
                listaTipos.Add(temp);
            }

            Database.Connection.OpenAsync();
            var query = new Mapa(Database);

            var dateIni = new DateTimeOffset(fechaInicio);
            var dateIniUnix = dateIni.ToUnixTimeSeconds();

            var dateFin = new DateTimeOffset(fechaFin);
            var dateFinUnix = dateFin.ToUnixTimeSeconds();

            List<Mapa> lista = query.obtenerPuntos(dateIniUnix, dateFinUnix, listaTipos);

            return lista;
        }
    }
}
