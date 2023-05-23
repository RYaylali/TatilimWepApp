using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.Controllers
{
	[AllowAnonymous]
	public class ErrorPageController : Controller
	{
		public IActionResult Error404()
		{
			return View();
		}
	}
}
