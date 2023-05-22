using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tatilim.BusinessLayer.Abstract;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SendMessageController : ControllerBase
	{
		private readonly ISendMessageService _sendMessageService;

		public SendMessageController(ISendMessageService sendMessageService)
		{
			_sendMessageService = sendMessageService;
		}

		[HttpGet]
		public IActionResult SendMessageList()
		{
			var values = _sendMessageService.TGetList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddSendMessage(SendMessage model)
		{
			_sendMessageService.TInsert(model);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteSendMessage(int id)
		{
			var values = _sendMessageService.TGetByID(id);

			_sendMessageService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateSendMessage(SendMessage model)
		{
			_sendMessageService.TUpdate(model);
			return Ok(model);
		}
		[HttpGet("{id}")]
		public IActionResult GetSendMessage(int id)
		{
			var values = _sendMessageService.TGetByID(id);
			return Ok(values);
		}

	}
}
