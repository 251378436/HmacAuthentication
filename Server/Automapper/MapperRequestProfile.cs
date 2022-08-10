using AutoMapper;
using Server.Models;
using Server.Models.Client;

namespace Server.Automapper
{
    public class MapperRequestProfile : Profile
    {
        public MapperRequestProfile()
        {
            CreateMap<MapperRequest, Car>();
            CreateMap<MapperRequest, MapperResponse>()
                .ForMember(d => d.FamilyCar, opt => opt.MapFrom(s => s));
        }
    }
}
