using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tatilim.BusinessLayer.Abstract;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribleService _SubscribeService;
        public SubscribeController(ISubscribleService subscribeService)
        {
            _SubscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _SubscribeService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddSubscribe(Subscribe model)
        {
            _SubscribeService.TInsert(model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSubscribe(int id)
        {
            var values = _SubscribeService.TGetByID(id);

            _SubscribeService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe model)
        {
            _SubscribeService.TUpdate(model);
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            var values = _SubscribeService.TGetByID(id);
            return Ok(values);
        }

    }
}
