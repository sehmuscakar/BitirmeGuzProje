using BusinessLayer.Abstract;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class BookingController : Controller
    {
        private readonly IBookingManager _bookingManager;

        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        public async Task<IActionResult> Index()
        {
            var listele = _bookingManager.GetList();
            return View(listele);
        }


        // GET: PostContactController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var datagetir =_bookingManager.GetByID(id);
            return View(datagetir);
        }

        // POST: PostContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Booking booking)
        {
            try
            {
                _bookingManager.Remove(booking);
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
