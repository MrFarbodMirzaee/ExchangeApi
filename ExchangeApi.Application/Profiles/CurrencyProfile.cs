using AutoMapper;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Domain.Entities;
using ExChangeApi.Domain.Entities;
using ExchangeApi.Application.UseCases.Currency.Commands;

namespace ExchangeApi.Application.Profiles;

public class CurrencyProfile : Profile
{
    public CurrencyProfile() 
    {
        CreateMap<Response<List<Currency>>, List<CurrencyDto>>();
        CreateMap<Response<Currency>, CurrencyDto>();
        CreateMap<List<CurrencyDto>, Currency>();
        CreateMap<List<CurrencyDto>, Currency>();
        CreateMap<List<Currency>, CurrencyDto>();


        CreateMap<Currency, List<CurrencyDto>>();
        CreateMap<CurrencyDto, Currency>();
        CreateMap<Currency, CurrencyDto>();
        CreateMap<AddCurencyDto, Currency>();
        CreateMap<Currency, AddCurencyDto>();
        CreateMap<AddCurrencyAttributeDto,CurrencyAttribute>();
        CreateMap<CurrencyAttribute, AddCurrencyAttributeDto>();
        CreateMap<AddCurrencyCommand, Currency>();
        CreateMap<bool, Currency>()
            .ConvertUsing(src => src ? new Currency() : null);

    }
}
