using AutoMapper;
using ExchangeApi.Contracts;
using ExchangeApi.Dtos;
using ExchangeApi.Models;

namespace ExchangeApi.Profiles;

public class IpAddressProfile : Profile
{
    public IpAddressProfile() 
    {
        CreateMap<string, IpAddress>()
            .ForMember(dest => dest.IPAddress, opt => opt.MapFrom(src => src));
    }
}
