using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.ViewComponents.Contact
{
    public class _ContactCoverPartial:ViewComponent
    {
        public IViewComponentResult Invoke ()
        {
            return View();
        }
    }
}
