using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tatilim.BusinessLayer.Abstract;
using Tatilim.DtoLayer.Dtos.RoomDto;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public Room2Controller(IMapper mapper, IRoomService roomService)
        {
            _mapper = mapper;
            _roomService = roomService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRoom(RoomAddDto roomAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(roomAddDto);
            _roomService.TInsert(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(model);
            _roomService.TUpdate(values);
            return Ok();
        }
    }
}
