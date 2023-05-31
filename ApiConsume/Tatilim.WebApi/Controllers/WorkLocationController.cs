using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tatilim.BusinessLayer.Abstract;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WorkLocationController : ControllerBase
	{
		private readonly IWorkLocationService _workLocationtService;

		public WorkLocationController(IWorkLocationService workLocationService)
		{
			_workLocationtService = workLocationService;
		}

		[HttpGet]
		public IActionResult WorkLocationList()
		{
			var values = _workLocationtService.TGetList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddWorkLocation(WorkLocation model)
		{
			_workLocationtService.TInsert(model);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteWorkLocation(int id)
		{
			var values = _workLocationtService.TGetByID(id);

			_workLocationtService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateWorkLocation(WorkLocation model)
		{
			_workLocationtService.TUpdate(model);
			return Ok(model);
		}
		[HttpGet("{id}")]
		public IActionResult GetWorkLocation(int id)
		{
			var values = _workLocationtService.TGetByID(id);
			return Ok(values);
		}

	}
}
