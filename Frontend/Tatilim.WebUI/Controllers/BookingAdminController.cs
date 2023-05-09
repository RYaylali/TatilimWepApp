﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Tatilim.WebUI.Dtos.BookingDto;
using Tatilim.WebUI.Dtos.ServiceDto;

namespace Tatilim.WebUI.Controllers
{
	public class BookingAdminController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BookingAdminController(IHttpClientFactory httpClientFactory)
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
		public async Task<IActionResult> ApprovedReservation(ApprovedReservationDto model)
		{
			model.Status = "Onaylandı";
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync($"http://localhost:5200/api/Booking/bbbb/{model.BookingID}", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

	}
}
