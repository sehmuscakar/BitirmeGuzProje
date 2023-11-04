using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class ServiceViewComponent:ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public ServiceViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _serviceManager.GetList();
            return View(listele);
        }

    }
}
