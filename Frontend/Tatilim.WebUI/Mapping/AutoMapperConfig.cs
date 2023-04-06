using AutoMapper;
using Tatilim.EntityLayer.Concrete;
using Tatilim.WebUI.Dtos.RegisterDto;
using Tatilim.WebUI.Dtos.ServiceDto;

namespace Tatilim.WebUI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();

            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
        }
    }
}
