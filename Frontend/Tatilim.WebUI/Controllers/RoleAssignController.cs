using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tatilim.EntityLayer.Concrete;
using Tatilim.WebUI.Models.Role;

namespace Tatilim.WebUI.Controllers
{
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

		public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public IActionResult Index()
        {
            var values = _userManager.Users.ToList();   
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user= _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userId"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignVM> roleAssignVMs = new List<RoleAssignVM>();
            foreach (var item in roles)
            {
                RoleAssignVM roleAssignVM = new RoleAssignVM();
                roleAssignVM.RoleID = item.Id;
                roleAssignVM.RoleName=item.Name;
                roleAssignVM.RoleExist = userRoles.Contains(item.Name);
                roleAssignVMs.Add(roleAssignVM);
            }
            return View(roleAssignVMs); 
        }
        [HttpPost]
		public async Task<IActionResult> AssignRole(List<RoleAssignVM> model)
        {
            var userid= (int)TempData["userId"];
            var user =_userManager.Users.FirstOrDefault(x=>x.Id==userid);
            foreach (var item in model)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("Index");
        }

	}
}
