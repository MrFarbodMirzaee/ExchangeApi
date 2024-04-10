using AutoMapper;
using ExchangeApi.Domain.Entitiess;
using ExchangeApi.Dtos;

namespace ExchangeApi.Profiles;

public class IpAddressProfile : Profile
{
    public IpAddressProfile() 
    {
        CreateMap<string, IpAddress>()
            .ForMember(dest => dest.IPAddress, opt => opt.MapFrom(src => src));
    }
}
