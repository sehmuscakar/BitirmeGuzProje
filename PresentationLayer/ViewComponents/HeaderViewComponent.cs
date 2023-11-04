using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly IContactCompanyManager _contactCompanyManager;

        public HeaderViewComponent(IContactCompanyManager contactCompanyManager)
        {
            _contactCompanyManager = contactCompanyManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _contactCompanyManager.GetList();
            return View(listele);
        }
    }
}
