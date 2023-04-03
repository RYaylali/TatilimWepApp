using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }
        public PartialViewResult NavPartial()
        {
            return PartialView();
        }
		public PartialViewResult PreloaderPartial()
		{
			return PartialView();
		}
		public PartialViewResult HeaderPartial()
		{
			return PartialView();
		}
		public PartialViewResult SidebarPartial()
		{
			return PartialView();
		}
		public PartialViewResult FooterPartial()
		{
			return PartialView();
		}
		public PartialViewResult ScriptPartial()
		{
			return PartialView();
		}
	}
}
