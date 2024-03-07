using AutoMapper;
using ExchangeApi.Dtos;
using ExChangeApi.Models;

namespace ExchangeApi.Profiles;

public class CurrencyProfile : Profile
{
    public CurrencyProfile() 
    {
        CreateMap<CurrencyDto, Currency>();
        CreateMap<Currency, CurrencyDto>();
    }
}
