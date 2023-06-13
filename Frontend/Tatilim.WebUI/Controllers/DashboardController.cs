using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
