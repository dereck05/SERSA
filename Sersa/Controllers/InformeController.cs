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
        public string obtenerNombreAsada(string id)
        {
            Database.Connection.OpenAsync();
            var query = new FormularioInforme(Database);
            string nombre = query.nombreAsada(id);
            return nombre;
        }

        public void guardarInforme(string listaFormularios, string idAsada)
        {
            Database.Connection.OpenAsync();
            var query = new FormularioInforme(Database);
            string nombre = obtenerNombreAsada(idAsada);
            long date = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            query.guardarInforme(nombre,listaFormularios,date);
            string idInforme = query.getLastInserted();
            query.guardarUsuarioxInforme(Autenticacion.get_idUsuario(), idInforme);

        }

        public ActionResult Informe_Sersa (string ids)
        {
            string[] parts = ids.Split(','); // Call Split method
            List<string> idList = new List<string>(parts); // Use List constructor

            Database.Connection.OpenAsync();
            var query = new FormularioInforme(Database);

            List<InformeResponse> lista = obtenerInformes(idList);
            
            string idAsada = lista[0].asada; //toma el primer formulario como referencia.
            guardarInforme(ids, idAsada);
            string nombreAsada = obtenerNombreAsada(idAsada);
            ActionResult action = query.buildPDF(lista,nombreAsada);
            return action;

        }



    }
}
