﻿using Microsoft.AspNetCore.Http;
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
		public IActionResult InboxListContact()
		{
			var values = _contactService.TGetList();
			return Ok(values);
		}
	 [HttpPost("PostContact")]
        public IActionResult AddContact(Contact contact)
        {
            contact.Date = Convert.ToDateTime(DateTime.Now.ToString());
            _contactService.TInsert(contact);
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
		public IActionResult GetSendMessage(int id)
		{
			var values = _contactService.TGetByID(id);
			return Ok(values);
		}
		[HttpGet("GetContactCount")]
		public IActionResult GetContactCount()
		{
			return Ok(_contactService.TGetContactCount());
		}

	}
}
