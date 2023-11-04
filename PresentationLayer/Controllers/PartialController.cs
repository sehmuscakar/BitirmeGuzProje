using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class PartialController : Controller
    {
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }



    }
}
