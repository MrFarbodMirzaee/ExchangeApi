using AutoMapper;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Application.Profiles;

public class IpAddressProfile : Profile
{
    public IpAddressProfile() 
    {
        CreateMap<string, IpAddress>()
            .ForMember(dest => dest.IPAddress, opt => opt.MapFrom(src => src));
    }
}
