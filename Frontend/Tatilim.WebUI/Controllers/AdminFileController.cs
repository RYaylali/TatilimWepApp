using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebUI.Controllers
{
	public class AdminFileController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(IFormFile file)
		{
			var stream = new MemoryStream();
			await file.CopyToAsync(stream);
			var bytes = stream.ToArray();

			ByteArrayContent content = new ByteArrayContent(bytes);
			content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
			MultipartFormDataContent contentFormData = new MultipartFormDataContent();
			contentFormData.Add(content, "file", file.FileName);
			var httpclient = new HttpClient();
			var responseMessage = await httpclient.PostAsync("http://localhost:5200/api/FileProsess", contentFormData);

			return View();
		}
	}
}
