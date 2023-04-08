using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.ViewComponents.Default
{
    public class _FooterPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
