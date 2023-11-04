using BusinessLayer.Abstract;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class PostContactController : Controller
    {
        private readonly IPostContactManager _postContactManager;

        public PostContactController(IPostContactManager postContactManager)
        {
            _postContactManager = postContactManager;
        }

        // GET: PostContactController
        public async Task<IActionResult> Index()
        {
            var listele = _postContactManager.GetList();
            return View(listele);
        }

    
        // GET: PostContactController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var datagetir=_postContactManager.GetByID(id);
            return View(datagetir);
        }

        // POST: PostContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, PostContact postContact)
        {
            try
            {
                _postContactManager.Remove(postContact);
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
