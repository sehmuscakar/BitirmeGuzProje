using BusinessLayer.Abstract;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ContactCompanyController : Controller
    {
        private readonly IContactCompanyManager _contactCompanyManager;

        public ContactCompanyController(IContactCompanyManager contactCompanyManager)
        {
            _contactCompanyManager = contactCompanyManager;
        }

        // GET: ContactCompanyController
        public async Task<IActionResult> Index()
        {
            // var listele =  _contactCompanyManager.GetList();
            var listeledto = _contactCompanyManager.GetContactCompanyListManager();
            return View(listeledto);
        }



        // GET: ContactCompanyController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: ContactCompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactCompany contactCompany, IFormFile? ImageUrl)
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
                        contactCompany.ImageUrl = ImageUrl.FileName;
                    }
                    _contactCompanyManager.Add(contactCompany);
                }
                    return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: ContactCompanyController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var datagetir = _contactCompanyManager.GetByID(id);
            return View(datagetir);
        }

        // POST: ContactCompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContactCompany contactCompany, IFormFile? ImageUrl)
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
                        contactCompany.ImageUrl = ImageUrl.FileName;
                    }
                    _contactCompanyManager.Update(contactCompany);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: ContactCompanyController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var datagetir = _contactCompanyManager.GetByID(id);
            return View(datagetir);
        }

        // POST: ContactCompanyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ContactCompany contactCompany, IFormFile? ImageUrl)
        {
            try
            {
                _contactCompanyManager.Remove(contactCompany);
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
