using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.ViewComponents.Default
{
    public class _HeadPartial : ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
