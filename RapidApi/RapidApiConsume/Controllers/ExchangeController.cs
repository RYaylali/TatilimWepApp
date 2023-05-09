using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
	public class ExchangeController : Controller
	{
		public async Task<IActionResult> Index()
		{
			
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
				Headers =
	{
		{ "X-RapidAPI-Key", "6d6022c3b4mshbc36fc3400f0258p181912jsn103af4efdabe" },
		{ "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var values =JsonConvert.DeserializeObject<ExchangeVM>(body);
				return View(values.exchange_rates.ToList());
			}
			
		}
	}
}
