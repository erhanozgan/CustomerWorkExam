using CustomerWork_Erhan.Context;
using CustomerWork_Erhan.Models;
using CustomerWork_Erhan.Models.Login;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomerWork_Erhan.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("KullaniciGirisYapti") != "evet")
            {
                return RedirectToAction("Index", "Login");

                 
            }
            return View();
        }

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