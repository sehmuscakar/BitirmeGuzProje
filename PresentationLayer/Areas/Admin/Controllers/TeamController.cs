using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class TeamController : Controller
    {
        private readonly ITeamManager _teamManager;

        public TeamController(ITeamManager teamManager)
        {
            _teamManager = teamManager;
        }

        // GET: TeamController
        public async Task<IActionResult> Index()
        {
            //  var listele = _teamManager.GetList();
            var listeledto = _teamManager.GetTeamListManager();
            return View(listeledto);
        }


        // GET: TeamController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: TeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Team team, IFormFile? ImageUrl)
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
                        team.ImageUrl = ImageUrl.FileName;
                    }
                   _teamManager.Add(team);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: TeamController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var datagetir=_teamManager.GetByID(id);
            return View(datagetir);
        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Team team, IFormFile? ImageUrl)
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
                        team.ImageUrl = ImageUrl.FileName;
                    }
                    _teamManager.Update(team);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: TeamController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var datagetir = _teamManager.GetByID(id);
            return View(datagetir);
        }

        // POST: TeamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id,Team team)
        {
            try
            {
                _teamManager.Remove(team);
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
