using Microsoft.AspNetCore.Mvc;
using System;

namespace SLNClinica.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Nombre = "Bienvenidos a otra DB de clinica!!";
            ViewBag.Fecha = DateTime.Now.ToString();
            return View();
        }

    }
}
