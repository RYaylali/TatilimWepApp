using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tatilim.EntityLayer.Concrete;
using Tatilim.WebUI.Dtos.AppUserDto;
using Tatilim.WebUI.Dtos.RoomDto;

namespace Tatilim.WebUI.Controllers
{
    public class AdminUsersController : Controller
    {
		//      private readonly UserManager<AppUser> _userManager;

		//public AdminUsersController(UserManager<AppUser> userManager)
		//{
		//	_userManager = userManager;
		//}

		//public IActionResult Index()
		//      {
		//          var values = _userManager.Users.ToList();
		//          return View(values);
		//      }
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminUsersController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5200/api/AppUser");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAppUserDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		public async Task<IActionResult> UserList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5200/api/AppUser/AppUserList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAppUserListDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
