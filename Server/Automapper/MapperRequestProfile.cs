using AutoMapper;
using Server.Models;
using Server.Models.Client;

namespace Server.Automapper
{
    public class MapperRequestProfile : Profile
    {
        public MapperRequestProfile()
        {
            CreateMap<MapperRequest, EMLAddress>();
            CreateMap<MapperRequest, EMLRegistration>()
                .ForMember(d => d.PrimaryAddress, opt => opt.MapFrom(s => s));
            CreateMap<MapperRequest, MapperResponse>()
                .ForMember(d => d.Registration, opt => opt.MapFrom(s => s));
        }
    }
}
