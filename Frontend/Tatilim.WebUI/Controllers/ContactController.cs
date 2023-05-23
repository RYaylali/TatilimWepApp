using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Tatilim.WebUI.Dtos.BookingDto;
using Tatilim.WebUI.Dtos.ContactDto;

namespace Tatilim.WebUI.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public ContactController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {
			createContactDto.Date = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:5200/api/Contact", stringContent);
            return RedirectToAction("Index", "Default");
        }
    }
}
