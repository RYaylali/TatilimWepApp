using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                List<BookingApiLocationSearchVM> model = new List<BookingApiLocationSearchVM>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
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
                    model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchVM>>(body);
                    return View(model.Take(1).ToList());//take ile indexin 1 incisini almaya yarar
                }
            }
            else
            {
                List<BookingApiLocationSearchVM> model = new List<BookingApiLocationSearchVM>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=Berlin&locale=en-gb"),
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
                    model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchVM>>(body);
                    return View(model.Take(1).ToList());//take ile indexin 1 incisini almaya yarar
                }
            }

        }
    }
}
