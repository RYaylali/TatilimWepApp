using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tatilim.WebUI.Dtos.BookingDto;
using Tatilim.WebUI.Dtos.ServiceDto;

namespace Tatilim.WebUI.Controllers
{
	public class BookingAdminController1 : Controller
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController1(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5200/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
      
	}
}
