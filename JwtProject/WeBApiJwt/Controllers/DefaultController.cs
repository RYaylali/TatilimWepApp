using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeBApiJwt.Models;

namespace WeBApiJwt.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DefaultController : ControllerBase
	{
		[HttpGet("[action]")]
		public IActionResult Get()
		{
			return Ok(new CreateToken().TokenCreate());
		}
		[HttpGet("[action]")]
		public IActionResult GetAdmin()
		{
			return Ok(new CreateToken().TokenCreateAdmin());
		}
		[Authorize]
		[HttpGet("[action]")]
		public IActionResult Test()
		{
			return Ok("Hoşgeldin");
		}
		[Authorize(Roles ="Admin,Visitor")]
		[HttpGet("[action]")]
		public IActionResult Test2()
		{
			return Ok("Token oluştu");
		}
	}
}
