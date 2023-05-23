using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tatilim.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FileProsessController : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
		{
			var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);//aynı isimde olmasını önlemek için
			var path = Path.Combine(Directory.GetCurrentDirectory(), "files/" + fileName);//dosyanın kayıt edilme yeri
			var stream = new FileStream(path, FileMode.Create);
			await file.CopyToAsync(stream);
			return Created("", file);

		}
	}
}
