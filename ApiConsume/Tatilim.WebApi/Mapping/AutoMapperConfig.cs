using AutoMapper;
using Tatilim.DtoLayer.Dtos.RoomDto;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.WebApi.Mapping
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();

        }
    }
}
