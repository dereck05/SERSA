using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sersa.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sersa.Controllers
{
    public class HistorialController : Controller
    {

        internal DBConnector Database { get; set; }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public HistorialController(DBConnector db)
        {
            Database = db;
        }

        public async Task<IActionResult> test()
        {
            await Database.Connection.OpenAsync();
            var query = new HistorialModel(Database);
            Console.Out.WriteLine("yes");
            await query.InsertAsync();
            return new OkObjectResult(query);
        }
    }
}
