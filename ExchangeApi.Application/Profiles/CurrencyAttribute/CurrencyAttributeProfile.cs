using AutoMapper;
using ExchangeApi.Application.Attributes;
using ExchangeApi.Application.Dtos;

namespace ExchangeApi.Application.Profiles.CurrencyAttribute;

[Profile]
public class CurrencyAttributeProfile : Profile
{
    public CurrencyAttributeProfile()
    {
        CreateMap<Domain.Entities.CurrencyAttribute, CurrencyAttributeDto>();
        CreateMap<CurrencyAttributeDto , Domain.Entities.CurrencyAttribute>();
    }
}