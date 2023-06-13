using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tatilim.WebUI.Dtos.BookingDto;
using Tatilim.WebUI.Dtos.GuestDto;
using Tatilim.WebUI.Dtos.StaffDto;

namespace Tatilim.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLastFourStaffList :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardLastFourStaffList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5200/api/Staff/Last4Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast4StaffDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
