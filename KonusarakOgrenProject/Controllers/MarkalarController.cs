using AppCorev1.Business.Models;
using Bussiness.Models;
using Bussiness.Services.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgrenProject.Controllers
{
    [Authorize]
    public class MarkalarController : Controller
    {
        private readonly IMarkaService _markaService;
        public MarkalarController(IMarkaService markaService)
        {
            _markaService = markaService;
        }

        // GET: MarkalarController
        public IActionResult Index()
        {
            List<MarkaModel> markaList = _markaService.Query().ToList(); // TODO: Add get list service logic here
            return View(markaList);
        }

        // GET: MarkalarController/Details/5
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return View("Hata!", "Id gereklidir!");
            MarkaModel marka = _markaService.Query().SingleOrDefault(m => m.Id == id); // TODO: Add get item service logic here
            if (marka == null)
            {
                return View("Hata!", "Marka bulunamadı!");
            }
            return View(marka);
        }

        // GET: MarkalarController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarkalarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MarkaModel marka)
        {
            if (ModelState.IsValid)
            {
                Result result = _markaService.Add(marka);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(marka);
        }

        // GET: MarkalarController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return View("Hata", "Id gereklidir!");
            }
            MarkaModel marka = _markaService.Query().SingleOrDefault(m => m.Id == id); // TODO: Add get item service logic here
            if (marka == null)
            {
                return View("Hata!", "Marka bulunamadı!");
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(marka);
        }

        // POST: MarkalarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MarkaModel marka)
        {
            if (ModelState.IsValid)
            {
                Result result = _markaService.Add(marka);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(marka);
        }

        // GET: MarkalarController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return View("Hata!", "Id gereklidir!");
            MarkaModel marka = _markaService.Query().SingleOrDefault(m => m.Id == id); // TODO: Add get item service logic here
            if (marka == null)
            {
                return View("Hata!", "Marka bulunamadı!");
            }
            return View(marka);
        }

        // POST: MarkalarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Result result = _markaService.Delete(id);
            TempData["Mesaj"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}
