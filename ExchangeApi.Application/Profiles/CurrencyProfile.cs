using AutoMapper;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Entitiess;
using ExChangeApi.Domain.Entities;

namespace ExchangeApi.Application.Profiles;

public class CurrencyProfile : Profile
{
    public CurrencyProfile() 
    {
        CreateMap<Response<List<Currency>>, List<CurrencyDto>>();
        CreateMap<Response<Currency>, CurrencyDto>();
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
