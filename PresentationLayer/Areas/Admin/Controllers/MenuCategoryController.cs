using BusinessLayer.Abstract;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class MenuCategoryController : Controller
    {
        private readonly IMenuCategoryManager _menuCategoryManager;
        public MenuCategoryController(IMenuCategoryManager menuCategoryManager)
        {
            _menuCategoryManager = menuCategoryManager;
        }
        // GET: MenuCategoryController
        public async Task<IActionResult> Index()
        {
            // var listele= _menuCategoryManager.GetList();
            var listeledto = _menuCategoryManager.GetMenuCatgoryListManager();
            return View(listeledto);
        }
        // GET: MenuCategoryController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }
        // POST: MenuCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuCategory menuCategory)
        {
            try
            {
                _menuCategoryManager.Add(menuCategory);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }
        // GET: MenuCategoryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var datagetir=_menuCategoryManager.GetByID(id);
            return View(datagetir);
        }
        // POST: MenuCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MenuCategory menuCategory)
        {
            try
            {
                _menuCategoryManager.Update(menuCategory);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }
        // GET: MenuCategoryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var datagetir = _menuCategoryManager.GetByID(id);
            return View(datagetir);
        }
        // POST: MenuCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id,MenuCategory menuCategory)
        {
            try
            {
                _menuCategoryManager.Remove(menuCategory);
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
