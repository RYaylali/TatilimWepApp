using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
