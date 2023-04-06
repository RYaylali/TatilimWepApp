using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tatilim.EntityLayer.Concrete;
using Tatilim.WebUI.Dtos.RegisterDto;

namespace Tatilim.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateNewUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Mail,
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(appUser,model.Password);//identity ile createasync metotu gelir metotun 2 overide var 
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }

            return View();
        }
    }
}
