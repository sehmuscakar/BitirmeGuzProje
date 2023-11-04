using BusinessLayer.Abstract;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class HeroController : Controller
    {
        private readonly IHeroManager _heroManager;

        public HeroController(IHeroManager heroManager)
        {
            _heroManager = heroManager;
        }

        // GET: HeroController
        public async Task<IActionResult> Index()
        {
            // var listele = _heroManager.GetList();
            var listeledto = _heroManager.GetHeroListManager();
            return View(listeledto);
        }
        // GET: HeroController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }
        // POST: HeroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hero hero)
        {
            try
            {
                _heroManager.Add(hero);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: HeroController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var datagetir=_heroManager.GetByID(id);
            return View(datagetir);
        }

        // POST: HeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Hero hero)
        {
            try
            {
                _heroManager.Update(hero);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: HeroController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var datagetir = _heroManager.GetByID(id);
            return View(datagetir);
        }

        // POST: HeroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id,Hero hero)
        {
            try
            {
                _heroManager.Remove(hero);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }
    }
}
