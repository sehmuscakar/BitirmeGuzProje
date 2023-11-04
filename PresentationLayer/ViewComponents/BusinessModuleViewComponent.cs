using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class BusinessModuleViewComponent:ViewComponent
    {
        private readonly IBusinessModuleManager _bussinesModuleManager;

        public BusinessModuleViewComponent(IBusinessModuleManager bussinesModuleManager)
        {
            _bussinesModuleManager = bussinesModuleManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _bussinesModuleManager.GetList();
            return View(listele);
        }
    }
}
