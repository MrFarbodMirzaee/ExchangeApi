using AutoMapper;
using ExchangeApi.Application.Dtos;
using ExChangeApi.Domain.Entities;

namespace ExchangeApi.Application.Profiles;

public class CurrencyProfile : Profile
{
    public CurrencyProfile() 
    {
        CreateMap<CurrencyDto, Currency>();
        CreateMap<Currency, CurrencyDto>();
        CreateMap<AddCurencyDto, Currency>();
        CreateMap<Currency, AddCurencyDto>();

        CreateMap<bool, Currency>()
            .ConvertUsing(src => src ? new Currency() : null);
    }
}
