using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tatilim.EntityLayer.Concrete;
using Tatilim.WebUI.Models.Role;

namespace Tatilim.WebUI.Controllers
{
	public class RoleController : Controller
	{
		private readonly RoleManager<AppRole>	_roleManager;

		public RoleController(RoleManager<AppRole> roleManager)
		{
			_roleManager = roleManager;
		}

		public  IActionResult Index()
		{
			var values =_roleManager.Roles.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddRole()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddRole(AddRoleVM model)
		{
			AppRole role = new AppRole()
			{
				Name = model.Name
			};
			var result = await _roleManager.CreateAsync(role);
			if (result.Succeeded)
			{
				return View("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteRole(int id)
		{
			var value = _roleManager.Roles.FirstOrDefault(x=>x.Id==id);
			await _roleManager.DeleteAsync(value);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateRole(int id)
		{
			var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
			UpdateRoleVM role = new UpdateRoleVM()
			{
				RoleID=value.Id,
				RoleName=value.Name
			};
			return View(role);
		}
		[HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleVM model)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == model.RoleID);
			value.Name = model.RoleName;
			await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");
        }
    }
}
