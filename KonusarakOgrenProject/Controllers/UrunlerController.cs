using Bussiness.Models;
using Bussiness.Services.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KonusarakOgrenProject.Controllers
{
    [Authorize]
    public class UrunlerController : Controller
    {
        // Add service injections here
        private readonly IUrunService _urunService;
        private readonly IMarkaService _markaService;

        public UrunlerController(IUrunService urunService, IMarkaService markaService)
        {
            _urunService = urunService;            
            _markaService = markaService;
        }

        // GET: UrunlerController
        //[AllowAnonymous]
        public IActionResult Index()
        {
            List<UrunModel> urunList = _urunService.Query().ToList(); // TODO: Add get list service logic here
            return View(urunList);
        }

        // GET: UrunlerController/Details/5

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Hata", "Kayıt bulunamadı!"); //404 
            }
            UrunModel urun = _urunService.Query().SingleOrDefault(u => u.Id == id.Value); // TODO: Add get item service logic here
            if (urun == null)
            {
                return View("Hata", "Kayıt bulunamadı!");
            }
            return View(urun);
        }

        // GET: UrunlerController/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            
            ViewData["MarkaId"] = new SelectList(_markaService.Query().ToList(), "Id", "Adi");
            return View();
        }

        // POST: UrunlerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(UrunModel urun)
        {
            if (ModelState.IsValid)
            {
                
                var result = _urunService.Add(urun);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
                return RedirectToAction(nameof(Index));
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            
            ViewData["MarkaId"] = new SelectList(_markaService.Query().ToList(), "Id", "Adi", urun.MarkaId);
            return View(urun);
        }

        // GET: UrunlerController/Edit/5
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Hata", "Id gereklidir!");
            }
            UrunModel urun = _urunService.Query().SingleOrDefault(u => u.Id == id); // TODO: Add get item service logic here
            if (urun == null)
            {
                return View("Hata", "Ürün bulunamadı!");
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            
            ViewData["MarkaId"] = new SelectList(_markaService.Query().ToList(), "Id", "Adi", urun.MarkaId);
            return View(urun);
        }

        // POST: UrunlerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(UrunModel urun)
        {
            if (ModelState.IsValid)
            {

                var result = _urunService.Add(urun);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
                return RedirectToAction(nameof(Index));
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items

            ViewData["MarkaId"] = new SelectList(_markaService.Query().ToList(), "Id", "Adi", urun.MarkaId);
            return View(urun);
        }

        // GET: UrunlerController/Delete/5
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Hata", "Id gereklidir!");
            }
            UrunModel urun = _urunService.Query().SingleOrDefault(u => u.Id == id); // TODO: Add get item service logic here
            if (urun == null)
            {
                return View("Hata", "Ürün bulunamadı!");
            }
            return View(urun);
        }

        // POST: UrunlerController/Delete/5
               
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            var result = _urunService.Delete(id);
            TempData["Mesaj"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}
