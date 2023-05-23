using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Tatilim.WebUI.Dtos.ServiceDto;
using Tatilim.WebUI.Dtos.SubscripleDto;

namespace Tatilim.WebUI.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult _SubscriblePartial()
        {
            return PartialView();
        }
		[HttpPost]
		public async Task<IActionResult> _SubscriblePartial(CreateSubscripleDto model)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5200/api/Subscribe", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index","Default");
			}
			return View();
		}

	}
}
