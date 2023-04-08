using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
