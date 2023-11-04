using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class MenuCategoryViewComponent:ViewComponent
    {
        private readonly IMenuCategoryManager _menuCategoryManager;

        public MenuCategoryViewComponent(IMenuCategoryManager menuCategoryManager)
        {
            _menuCategoryManager = menuCategoryManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _menuCategoryManager.GetList();
            return View(listele);
        }
    }
}
