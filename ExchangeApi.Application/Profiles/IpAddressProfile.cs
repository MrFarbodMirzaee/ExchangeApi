using AutoMapper;
using ExchangeApi.Domain.Entitiess;
using ExchangeApi.Application.Dtos;

namespace ExchangeApi.Application.Profiles;

public class IpAddressProfile : Profile
{
    public IpAddressProfile() 
    {
        CreateMap<string, IpAddress>()
            .ForMember(dest => dest.IPAddress, opt => opt.MapFrom(src => src));
    }
}
