using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tatilim.BusinessLayer.Abstract;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public IActionResult GuestList()
        {
            var values = _guestService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddGuest(Guest model)
        {
            _guestService.TInsert(model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletGuest(int id)
        {
            var values = _guestService.TGetByID(id);

            _guestService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateGuest(Guest model)
        {
            _guestService.TUpdate(model);
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult GetGuest(int id)
        {
            var values = _guestService.TGetByID(id);
            return Ok(values);
        }

    }
}
