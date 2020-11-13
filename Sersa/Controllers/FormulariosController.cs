using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sersa.Models;

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


        public async Task<IActionResult> guardarFormularioFS(DateTime FECHA, string ACUEDUCTO, string TOMA, string REGISTRO, string DIRECCION,string ENCARGADO,string TELEFONO,
                    string FUNCIONARIO, string LATITUD,string LONGITUD, string IMG, string LIMPIEZA, string ESPECIFIQUE, string NOTAS, string P1,
                    string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9, string P10, string IOU, string ID)
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
            var query = new FormulariosModel(Database);
            if (IOU == "I")
            {
                await query.InsertFormularioFS(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
            else
            {
                await query.UpdateFormularioFS(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS,ID);
                var resultado = new OkObjectResult(query);
                return resultado;
            }

        }

        public async Task<IActionResult> guardarFormularioFN(DateTime FECHA, string ACUEDUCTO, string NACIENTE, string REGISTRO, string DIRECCION, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, string CAPTACION, string NOTAS, string P1,
                    string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9, string P10, string IOU, string ID)
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

            FNInfoGeneral ig = new FNInfoGeneral();
            ig.Naciente = NACIENTE;
            ig.Captacion = CAPTACION;
            ig.Registro = REGISTRO;
            ig.Direccion = DIRECCION;

            await Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            if (IOU == "I")
            {
                await query.InsertFormularioFN(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
            else
            {
                await query.UpdateFormularioFN(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS, ID);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
        }

        public async Task<IActionResult> guardarFormularioP(DateTime FECHA, string ACUEDUCTO, string POZO, string REGISTRO, string SENASA, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, string FRIATICO, string DINAMICO, string DIAMETRO, string ESPESOR, string TIPOP, string NOTAS, string P1,
                    string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9, string P10, string IOU, string ID)
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

            PInfoGeneral ig = new PInfoGeneral();
            ig.Senasa = SENASA;
            ig.Pozo = POZO;
            ig.Registro = REGISTRO;
            ig.FRIATICO = FRIATICO;
            ig.DINAMICO = DINAMICO;
            ig.DIAMETRO = DIAMETRO;
            ig.ESPESOR = ESPESOR;
            ig.TIPOP = TIPOP;

            await Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            if (IOU == "I")
            {
                await query.InsertFormularioP(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
            else
            {
                await query.UpdateFormularioP(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS, ID);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
        }

        public async Task<IActionResult> guardarFormularioA(DateTime FECHA, string ACUEDUCTO, string TANQUE, string REGISTRO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, string TIPOTANQUE, string MATTANQUE, string LIMPIEZA, string NOTAS, string P1,
                    string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9, string P10, string IOU, string ID)
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

            AInfoGeneral ig = new AInfoGeneral();
            ig.Registro = REGISTRO;
            ig.Tanque = TANQUE;
            ig.TipoTanque = TIPOTANQUE;
            ig.MatTanque = MATTANQUE;
            ig.Limpieza = LIMPIEZA;

            await Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            if (IOU == "I")
            {
                await query.InsertFormularioA(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
            else
            {
                await query.UpdateFormularioA(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS, ID);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
        }

        public async Task<IActionResult> guardarFormularioC(DateTime FECHA, string ACUEDUCTO, string CONDUCCIONTANQUE, string REPARACIONES, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, string FECHACONSTRUCCION, string MATTUBERIA, string NOTAS, string P1,
                    string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9, string P10, string IOU, string ID)
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

            CInfoGeneral ig = new CInfoGeneral();
            ig.ConduccionTanque = CONDUCCIONTANQUE;
            ig.Reparaciones = REPARACIONES;
            ig.FechaConstruccion = FECHACONSTRUCCION;
            ig.MatTuberia = MATTUBERIA;

            await Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            if (IOU == "I")
            {
                await query.InsertFormularioC(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
            else
            {
                await query.UpdateFormularioC(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS, ID);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
        }

        public async Task<IActionResult> guardarFormularioD(DateTime FECHA, string ACUEDUCTO, string REPARACIONES, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, string FECHACONSTRUCCION, string MATTUBERIA, string NOTAS, string P1,
                    string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9, string P10, string IOU, string ID)
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

            DInfoGeneral ig = new DInfoGeneral();
            ig.Reparaciones = REPARACIONES;
            ig.FechaConstruccion = FECHACONSTRUCCION;
            ig.MatTuberia = MATTUBERIA;

            await Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            if (IOU == "I")
            {
                await query.InsertFormularioD(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
            else
            {
                await query.UpdateFormularioD(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS, ID);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
        }


        public async Task<IActionResult> guardarFormularioQ(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, string FECHACONSTRUCCION, string MATTUBERIA, string LIMPIEZA, string NOTAS, string P1,
                    string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9, string P10, string IOU, string ID)
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

            QInfoGeneral ig = new QInfoGeneral();
            ig.Limpieza = LIMPIEZA;
            ig.FechaConstruccion = FECHACONSTRUCCION;
            ig.MatTuberia = MATTUBERIA;

            await Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            if (IOU == "I")
            {
                await query.InsertFormularioQ(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
            else
            {
                await query.UpdateFormularioQ(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS, ID);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
        }

        public async Task<IActionResult> guardarFormularioCl(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, string FECHACONSTRUCCION, string FECHAINSTALACION, string TIPOSISTEMA, string TIPODOSIFICACION, string NOTAS, string P1,
                    string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9, string P10, string IOU, string ID)
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

            ClInfoGeneral ig = new ClInfoGeneral();
            ig.FechaInstalacion = FECHAINSTALACION;
            ig.FechaConstruccion = FECHACONSTRUCCION;
            ig.TipoSistema = TIPOSISTEMA;
            ig.TipoDosificacion = TIPODOSIFICACION;

            await Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            if (IOU == "I")
            {
                await query.InsertFormularioCl(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
            else
            {
                await query.UpdateFormularioCl(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS, ID);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
        }

        public async Task<IActionResult> guardarFormularioPP(DateTime FECHA, string ACUEDUCTO, string ENCARGADO, string TELEFONO,
                    string FUNCIONARIO, string LATITUD, string LONGITUD, string IMG, string FECHACONSTRUCCION, string SISTEMAPOT, string ESPECIFIQUE, string NOTAS, string P1,
                    string P2, string P3, string P4, string P5, string P6, string P7, string P8, string P9, string P10, string IOU, string ID)
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

            PPInfoGeneral ig = new PPInfoGeneral();
            ig.SistemaPot = SISTEMAPOT;
            ig.FechaConstruccion = FECHACONSTRUCCION;
            ig.Especifique = ESPECIFIQUE;

            await Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            if (IOU == "I")
            {
                await query.InsertFormularioPP(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
            else
            {
                await query.UpdateFormularioPP(FECHA, ACUEDUCTO, ENCARGADO, TELEFONO,
                     FUNCIONARIO, LATITUD, LONGITUD, IMG, f, ig, NOTAS, ID);
                var resultado = new OkObjectResult(query);
                return resultado;
            }
        }


        public PartialViewResult llenarTablaListaFS()
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            List<Formularios> lista = new List<Formularios>();
            lista = query.llenarTablaListaFS();

            return PartialView("_LayoutListarFS", lista);

        }

        public PartialViewResult llenarTablaListaFN()
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            List<Formularios> lista = new List<Formularios>();
            lista = query.llenarTablaListaFN();

            return PartialView("_LayoutListarFN", lista);

        }

        public PartialViewResult llenarTablaListaP()
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            List<Formularios> lista = new List<Formularios>();
            lista = query.llenarTablaListaP();

            return PartialView("_LayoutListarP", lista);

        }

        public PartialViewResult llenarTablaListaA()
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            List<Formularios> lista = new List<Formularios>();
            lista = query.llenarTablaListaA();

            return PartialView("_LayoutListarA", lista);

        }

        public PartialViewResult llenarTablaListaC()
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            List<Formularios> lista = new List<Formularios>();
            lista = query.llenarTablaListaC();

            return PartialView("_LayoutListarC", lista);

        }

        public PartialViewResult llenarTablaListaD()
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            List<Formularios> lista = new List<Formularios>();
            lista = query.llenarTablaListaD();

            return PartialView("_LayoutListarD", lista);

        }

        public PartialViewResult llenarTablaListaQ()
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            List<Formularios> lista = new List<Formularios>();
            lista = query.llenarTablaListaQ();

            return PartialView("_LayoutListarQ", lista);

        }

        public PartialViewResult llenarTablaListaCl()
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            List<Formularios> lista = new List<Formularios>();
            lista = query.llenarTablaListaCl();

            return PartialView("_LayoutListarCl", lista);

        }

        public PartialViewResult llenarTablaListaPP()
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            List<Formularios> lista = new List<Formularios>();
            lista = query.llenarTablaListaPP();

            return PartialView("_LayoutListarPP", lista);

        }

        public string obtenerFormularioFS(string ID)
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            string resultado = query.obtenerFormularioFS(ID);

            return resultado;
        }

        public string obtenerFormularioFN(string ID)
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            string resultado = query.obtenerFormularioFN(ID);

            return resultado;
        }

        public string obtenerFormularioP(string ID)
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            string resultado = query.obtenerFormularioP(ID);

            return resultado;
        }

        public string obtenerFormularioA(string ID)
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            string resultado = query.obtenerFormularioA(ID);

            return resultado;
        }

        public string obtenerFormularioC(string ID)
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            string resultado = query.obtenerFormularioC(ID);

            return resultado;
        }

        public string obtenerFormularioD(string ID)
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            string resultado = query.obtenerFormularioD(ID);

            return resultado;
        }

        public string obtenerFormularioCl(string ID)
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            string resultado = query.obtenerFormularioCl(ID);

            return resultado;
        }

        public string obtenerFormularioPP(string ID)
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            string resultado = query.obtenerFormularioPP(ID);

            return resultado;
        }

        public string obtenerFormularioQ(string ID)
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            string resultado = query.obtenerFormularioQ(ID);

            return resultado;
        }

        public string eliminarFormulario(string ID)
        {

            Database.Connection.OpenAsync();
            var query = new FormulariosModel(Database);
            string resultado = query.eliminarFormulario(ID);

            return resultado;
        }


    }
}

