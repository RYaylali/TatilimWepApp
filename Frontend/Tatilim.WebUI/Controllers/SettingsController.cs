using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tatilim.EntityLayer.Concrete;
using Tatilim.WebUI.Models.Settings;

namespace Tatilim.WebUI.Controllers
{
	public class SettingsController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public SettingsController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditVM userModel = new UserEditVM();
			userModel.Name = user.UserName;
			userModel.Surname = user.Surname;
			userModel.Email = user.Email;
			userModel.Username = user.UserName;
			return View(userModel);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserEditVM model)
		{
			if (model.ConfirmPassword==model.Password)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				user.Name = model.Name;
				user.Surname = model.Surname;
				user.Email = model.Email;
				user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
				await _userManager.UpdateAsync(user);
				return RedirectToAction("Index","Login");
			}
			return View();
		}
	}
}
