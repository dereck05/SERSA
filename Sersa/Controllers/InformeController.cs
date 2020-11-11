using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sersa.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sersa.Controllers
{
    public class InformeController : Controller
    {
        internal DBConnector Database { get; set; }

        public InformeController(DBConnector db)
        {
            Database = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult filtrarInformes(DateTime FechaInicio, DateTime FechaFin)
        {
            Database.Connection.OpenAsync();
            var query = new FormularioInforme(Database);
            var dateIni = new DateTimeOffset(FechaInicio);
            var dateIniUnix = dateIni.ToUnixTimeSeconds();

            var dateFin = new DateTimeOffset(FechaFin);
            var dateFinUnix = dateFin.ToUnixTimeSeconds();

            List<FormularioInforme> lista = query.obtenerFormularioInforme(dateIniUnix, dateFinUnix);

            return PartialView("_FormularioInforme",lista);

        }
        public List<InformeResponse> obtenerInformes(List<string> ids)
        {
            Database.Connection.OpenAsync();
            var query = new FormularioInforme(Database);
            List<InformeResponse> lista = query.obtenerInformesSeleccionados(ids);
            return lista;
        }

        public ActionResult Informe_Sersa (string ids)
        {
            string[] parts = ids.Split(','); // Call Split method
            List<string> idList = new List<string>(parts); // Use List constructor

            Console.WriteLine("HEREEEEE:"+idList.Count);
            Database.Connection.OpenAsync();
            var query = new FormularioInforme(Database);

            List<InformeResponse> lista = obtenerInformes(idList);

            ActionResult action = query.buildPDF(lista);
            return action;

        }



    }
}
