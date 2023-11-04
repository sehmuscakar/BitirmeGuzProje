using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class HeroViewComponent:ViewComponent
    {
        private readonly IHeroManager _heroManager;

        public HeroViewComponent(IHeroManager heroManager)
        {
            _heroManager = heroManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _heroManager.GetList();
            return View(listele);
        }
    }
}
