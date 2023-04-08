using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.ViewComponents.Default
{
    public class _SliderPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
