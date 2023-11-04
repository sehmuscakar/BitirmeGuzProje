using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class GalleryController : Controller
    {
        private readonly IGalleryManager _galleryManager;

        public GalleryController(IGalleryManager galleryManager)
        {
            _galleryManager = galleryManager;
        }

        // GET: GalleryController
        public async Task<IActionResult> Index()
        {
            //  var listele = _galleryManager.GetList();
            var listeledto = _galleryManager.GetGalleryListManager();
            return View(listeledto);
        }

        // GET: GalleryController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: GalleryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gallery gallery, IFormFile? ImageUrl)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (ImageUrl is not null)
                    {
                        string klasor1 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + ImageUrl.FileName;
                        using var stream1 = new FileStream(klasor1, FileMode.Create);
                        ImageUrl.CopyTo(stream1);
                        gallery.ImageUrl = ImageUrl.FileName;
                    }
                    _galleryManager.Add(gallery);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: GalleryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var datagetir=_galleryManager.GetByID(id);
            return View(datagetir);
        }

        // POST: GalleryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Gallery gallery, IFormFile? ImageUrl)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (ImageUrl is not null)
                    {
                        string klasor1 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + ImageUrl.FileName;
                        using var stream1 = new FileStream(klasor1, FileMode.Create);
                        ImageUrl.CopyTo(stream1);
                        gallery.ImageUrl = ImageUrl.FileName;
                    }
                    _galleryManager.Update(gallery);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: GalleryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var datagetir = _galleryManager.GetByID(id);
            return View(datagetir);
        }

        // POST: GalleryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Gallery gallery)
        {
            try
            {
                _galleryManager.Remove(gallery);    
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
