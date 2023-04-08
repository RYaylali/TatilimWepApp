using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.ViewComponents.Default
{
    public class _NavbarPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
