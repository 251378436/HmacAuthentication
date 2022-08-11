using AutoMapper;
using Server.Models;
using Server.Models.Client;

namespace Server.Automapper
{
    public class MapperRequestProfile : Profile
    {
        public MapperRequestProfile()
        {
            CreateMap<MapperRequest, EMLAddress>()
                .ForMember(d => d.AddressLine1, opt => opt.Ignore())
                .ForMember(d => d.AddressLine2, opt => opt.Ignore())
                .ForMember(d => d.AddressLine3, opt => opt.Ignore())
                .ForMember(d => d.City, opt => opt.Ignore());

            CreateMap<MapperRequest, EMLRegistration>()
                .ForMember(d => d.PrimaryAddress, opt => opt.MapFrom(s => s));
            CreateMap<MapperRequest, MapperResponse>()
                .ForMember(d => d.Registration, opt => opt.MapFrom(s => s))
                .ForMember(d => d.CompanyId, opt => opt.Ignore())
                .ForMember(d => d.InitialLoadAmount, opt => opt.Ignore());
        }
    }
}
