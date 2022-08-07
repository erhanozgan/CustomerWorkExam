using CustomerWork_Erhan.Context;
using CustomerWork_Erhan.Models.Login;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWork_Erhan.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login model)
        {
            //çalıştıralım.
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(nameof(model.UserName), "isvalid çalıştı");
            }
            HttpContext.Session.SetString("KullaniciGirisYapti", "evet");
            var user = _context.login.FirstOrDefault(t=>t.UserPassword == model.UserPassword && t.UserName == model.UserName);
            //HttpContext.Session.SetString("userModel", user);

            if (user is null)
            {
                ModelState.AddModelError(nameof(model.UserName), "Kullanıcı kodu veya şifreniz hatalı");
                return View(model);
            }
            return RedirectToAction(nameof(Index), "Home");
        }


    }
}
