using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.ViewComponents.Default
{
    public class _ScriptPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
