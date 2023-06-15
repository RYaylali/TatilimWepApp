using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tatilim.WebUI.Dtos.FollowersDto;

namespace Tatilim.WebUI.ViewComponents.Dashboard
{
	public class _DashboardSubscribeCountPartial : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/yaylali_ramazan"),
				Headers =
	{
		{ "X-RapidAPI-Key", "6d6022c3b4mshbc36fc3400f0258p181912jsn103af4efdabe" },
		{ "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				ResultInstagramFollowersDto apiInstagramVM = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
				ViewBag.v1 = apiInstagramVM.followers;
				ViewBag.v2 = apiInstagramVM.following;
			}
			var client2 = new HttpClient();
			var request2 = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=Elifgokoglan"),
				Headers =
	{
		{ "X-RapidAPI-Key", "6d6022c3b4mshbc36fc3400f0258p181912jsn103af4efdabe" },
		{ "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
	},
			};
			using (var response2 = await client2.SendAsync(request2))
			{
				response2.EnsureSuccessStatusCode();
				var body2 = await response2.Content.ReadAsStringAsync();
				ResultTwitterFollowersDto apiTwitterVM = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body2);
				ViewBag.t1 = apiTwitterVM.data.user_info.friends_count;
				ViewBag.t2 = apiTwitterVM.data.user_info.followers_count;
			}
			var client3 = new HttpClient();
			var request3 = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Framazan-yaylali-126128137%2F"),
				Headers =
	{
		{ "X-RapidAPI-Key", "6d6022c3b4mshbc36fc3400f0258p181912jsn103af4efdabe" },
		{ "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
	},
			};
			using (var response3 = await client3.SendAsync(request3))
			{
				response3.EnsureSuccessStatusCode();
				var body3 = await response3.Content.ReadAsStringAsync();
				ResultLinkedinFollowersDto apiLinkedinVM = JsonConvert.DeserializeObject<ResultLinkedinFollowersDto>(body3);
				ViewBag.l1 = apiLinkedinVM.data.followers_count;
			}
			return View();
		}
	}
}
