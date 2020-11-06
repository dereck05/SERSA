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

        public IActionResult filtrarInformes()
        {
            Database.Connection.OpenAsync();
            var query = new FormularioInforme(Database);
            string fIni = "1601510400";
            string fFin = "1604361600";
            List<FormularioInforme> lista = query.obtenerFormularioInforme(Int32.Parse(fIni), Int32.Parse(fFin));

            return PartialView("_FormularioInforme",lista);

        }
    }
}
