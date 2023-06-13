using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.ViewComponents.Dashboard
{
    public class _DashboardHeadPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
