using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sersa.Models;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
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
            if (Autenticacion.get_idUsuario() != -1)
            {
                var result1 = query.GetAsadas();
            }
            var r = new OkObjectResult(result);
            if (!r.Equals("")) {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, result[0].id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, result[0].tipo.ToString()));
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal, new AuthenticationProperties { ExpiresUtc=DateTime.Now.AddDays(1), IsPersistent=true});
            }
            return new OkObjectResult(result);
        }
        public IActionResult Logout() {
            Autenticacion.set_idAsada("");
            Autenticacion.set_idUsuario(-1);
            Autenticacion.set_tipo(-1);
            HttpContext.SignOutAsync();
            return Redirect("/Login");
        }

    }
}
