using AutoMapper;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Entities;
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
        CreateMap<AddCurrencyAttributeDto,CurrencyAttribute>();
        CreateMap<CurrencyAttribute, AddCurrencyAttributeDto>();
      
        CreateMap<bool, Currency>()
            .ConvertUsing(src => src ? new Currency() : null);
    }
}
