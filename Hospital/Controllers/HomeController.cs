using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HospitalCitas.Models;
using System.Web;

namespace Hospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index(string message = "")
        //{
        //    ViewBag.Message = message;
        //    return View();
        //}
        //[HttpPost]

        //public IActionResult Login(string email, string password)
        //{
        //    if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
        //    {
        //        HospitalContext db = new HospitalContext();
        //        var secre = db.Secretaria.FirstOrDefault(e => e.Correo == email && e.Contrasena == password);
        //        //si secretaria es diferente de null
        //        if (secre != null)
        //        {
        //            //encontramos una secretaria con los datos
        //            // FormsAuthentication.SetAuthCookie(email, true);
        //            return RedirectToAction("Index", "Profile");

        //        }
        //        else
        //        {
        //            return Index("No encontramos tus datos");
        //        }
        //    }
        //    else
        //    {
        //        return Index("Por favor llenar los campos para iniciar sesion");
        //    }

        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
