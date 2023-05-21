using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tatilim.BusinessLayer.Abstract;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public IActionResult ContactList()
		{
			var values = _contactService.TGetList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddContact(Contact model)
		{
			model.Date=Convert.ToDateTime(DateTime.Now.ToString());
			_contactService.TInsert(model);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteContact(int id)
		{
			var values = _contactService.TGetByID(id);

			_contactService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateContact(Contact model)
		{
			_contactService.TUpdate(model);
			return Ok(model);
		}
		[HttpGet("{id}")]
		public IActionResult GetContact(int id)
		{
			var values = _contactService.TGetByID(id);
			return Ok(values);
		}

	}
}
