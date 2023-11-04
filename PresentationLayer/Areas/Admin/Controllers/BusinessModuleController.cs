using BusinessLayer.Abstract;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class BusinessModuleController : Controller
    {
        private readonly IBusinessModuleManager _bussinesModuleManager;

        public BusinessModuleController(IBusinessModuleManager bussinesModuleManager)
        {
            _bussinesModuleManager = bussinesModuleManager;
        }

        // GET: BusinessModuleController
        public async Task<IActionResult> Index()
        {
            //  var listele = _bussinesModuleManager.GetList();
            var listeledto = _bussinesModuleManager.GetBusinessModuleListManager();
            return View(listeledto);
        }



        // GET: BusinessModuleController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: BusinessModuleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( BusinessModule businessModule , IFormFile? ImageUrl)
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
                       businessModule.ImageUrl = ImageUrl.FileName;
                    }
                    _bussinesModuleManager.Add(businessModule);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: BusinessModuleController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var datagetir = _bussinesModuleManager.GetByID(id);
            return View(datagetir);
        }

        // POST: BusinessModuleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BusinessModule businessModule, IFormFile? ImageUrl)
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
                        businessModule.ImageUrl = ImageUrl.FileName;
                    }
                    _bussinesModuleManager.Update(businessModule);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: BusinessModuleController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var datagetir = _bussinesModuleManager.GetByID(id);
            return View(datagetir);
        }

        // POST: BusinessModuleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, BusinessModule businessModule)
        {
            try
            {
                _bussinesModuleManager.Remove(businessModule);
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
