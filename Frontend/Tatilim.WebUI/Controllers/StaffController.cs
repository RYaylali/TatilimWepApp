using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
