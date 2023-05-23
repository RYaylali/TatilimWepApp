using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tatilim.EntityLayer.Concrete;
using Tatilim.WebUI.Dtos.LoginDto;

namespace Tatilim.WebUI.Controllers
{
	[AllowAnonymous]//Yetkisiz girilebilir
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task< IActionResult> Index(LoginUserDto model)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Staff");
				}
				else
				{
					return View();
				}
			}
			return View();
		}
	}
}
