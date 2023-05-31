using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tatilim.BusinessLayer.Abstract;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService _messageCategoryService;

        public MessageCategoryController(IMessageCategoryService messageCategoryService)
        {
            _messageCategoryService = messageCategoryService;
        }

        [HttpGet]
        public IActionResult MessageCategoryList()
        {
            var values = _messageCategoryService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddMessageCategory(MessageCategory model)
        {
            _messageCategoryService.TInsert(model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessageCategory(int id)
        {
            var values = _messageCategoryService.TGetByID(id);
            _messageCategoryService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateMessageCategory(MessageCategory model)
        {
            _messageCategoryService.TUpdate(model);
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult GetMessageCategory(int id)
        {
            var values = _messageCategoryService.TGetByID(id);
            return Ok(values);
        }

    }
}
