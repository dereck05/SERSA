using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sersa.Models;
using System.Diagnostics;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sersa.Controllers
{
    public class LoginController : Controller
    {
        internal DBIrsassConnector Database { get; set; }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public LoginController(DBIrsassConnector db)
        {
            Database = db;
        }
        public IActionResult GetUsers(string USER, string PASSWORD)
        {
            Database.Connection.OpenAsync();
            var query = new LoginModel(Database);
            var result = query.credentialsValidate(USER,PASSWORD);

            return new OkObjectResult(result);
        }

    }
}
