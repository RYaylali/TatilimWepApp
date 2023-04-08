using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.Controllers
{
	public class RoomController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
