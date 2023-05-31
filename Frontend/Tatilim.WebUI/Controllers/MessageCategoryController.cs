using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.Controllers
{
    public class MessageCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
