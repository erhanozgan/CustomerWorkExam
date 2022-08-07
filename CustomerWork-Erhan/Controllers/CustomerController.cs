using CustomerWork_Erhan.Context;
using CustomerWork_Erhan.Models.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CustomerWork_Erhan.Controllers
{
    public class CustomerController : Controller
    {
        #region Context
        private readonly DataContext _context;

        public CustomerController(DataContext context)
        {
            _context = context;
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("KullaniciGirisYapti") != "evet")
            {
                return RedirectToAction("Index", "Login");


            }
            return View(await _context.Customer.Include(t => t.Country).Include(t => t.City).Include(t => t.CustomerType).ToListAsync());

        }

        public async Task<IActionResult> Create()
        {
            ViewBag.CustomerType = new SelectList(await _context.CustomerType.ToListAsync(), "Id", "Description");
            ViewBag.Country = new SelectList(await _context.Country.ToListAsync(), "Id", "Description");
            ViewBag.City = new SelectList(await _context.City.ToListAsync(), "Id", "Description");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Customer model)
        {
            if (ModelState.IsValid)
            {

                //model.Description = model.Description.Trim();
                _context.Add(model);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    TempData["Success"] = "Kayıt ekleme başarılı...";

                }
                else
                {
                    ViewBag.Error = $"İşlem sırasında hata oluştu.";
                    return RedirectToAction("Create");
                }

            }
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? Id)
        {

            if (Id is null)
            {
                return RedirectToAction(nameof(Index));
            }
            var data = _context.Customer.Where(t => t.Id == Id).FirstOrDefault();
            if (data is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int? Id)
        {
            var data = _context.Customer.Find(Id);

            if (data is null)
                return RedirectToAction(nameof(Index));

            _context.Remove(data);
            var result = _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public JsonResult CityGet(int countryId)
        {
            var cities = _context.City.Where(t => t.CountryId == countryId).ToList();

            return Json(cities);
        }
    }
}
