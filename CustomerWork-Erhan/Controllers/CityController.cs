using CustomerWork_Erhan.Context;
using CustomerWork_Erhan.Models.Location;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CustomerWork_Erhan.Controllers
{
    public class CityController : Controller
    {
        #region Context
        private readonly DataContext _context;

        public CityController(DataContext context)
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
            return View(await _context.City.Include(t=>t.Country).ToListAsync());

        }

        public async Task<IActionResult> Create()
        {
            ViewData["asd"] =
            new SelectList(await _context.Country.ToListAsync(), "Id", "Description");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(City model)
        {
            if (ModelState.IsValid)
            {

                model.Description = model.Description.Trim();
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
            var data = _context.City.Where(t => t.Id == Id).FirstOrDefault();
            if (data is null) { 
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int? Id)
        {
            var data =  _context.City.Find(Id);

            if (data is null)
                return RedirectToAction(nameof(Index));

           

            _context.Remove(data);
            var result =  _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
