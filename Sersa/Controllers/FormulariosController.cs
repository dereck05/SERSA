using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sersa.Controllers
{
    public class FormulariosController : Controller
    {
        internal DBConnector Database { get; set; }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public FormulariosController(DBConnector db)
        {
            Database = db;
        }

        public async Task<IActionResult> test()
        {
            await Database.Connection.OpenAsync();
            var query = new FormularioModel(Database);
            Console.Out.WriteLine("yes");
            await query.InsertAsync();
            return new OkObjectResult(query);
        }

        public async Task<IActionResult> guardarFormularioFS(string FECHA, string ACUEDUCTO, string TOMA, string REGISTRO, string DIRECCION,string ENCARGADO,string TELEFONO,
                    string FUNCIONARIO, string LATITUD,string LONGITUD, string IMG, string LIMPIEZA, string ESPECIFIQUE, string NOTAS, string P1,
                    string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9, string P10)
        {
            FormularioRespuesta f = new FormularioRespuesta();
            f.P1 = P1;
            f.P2 = P2;
            f.P3 = P3;
            f.P4 = P4;
            f.P5 = P5;
            f.P6 = P6;
            f.P7 = P7;
            f.P8 = P8;
            f.P9 = P9;
            f.P10 = P10;

            FSInfoGeneral ig = new FSInfoGeneral();
            ig.Limpieza = LIMPIEZA;
            ig.Especificacion = ESPECIFIQUE;
            ig.Toma = TOMA;
            ig.Registro = REGISTRO;
            ig.Direccion = DIRECCION;

            await Database.Connection.OpenAsync();
            var query = new FormularioModel(Database);
            await query.InsertFormularioFS( FECHA,  ACUEDUCTO,  ENCARGADO,  TELEFONO,
                     FUNCIONARIO,  LATITUD,  LONGITUD,  IMG, f, ig, NOTAS);
            var resultado =  new OkObjectResult(query);

            return resultado;
        }

    }
}

