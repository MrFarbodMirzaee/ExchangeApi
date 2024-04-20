using AutoMapper;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Entities;


namespace ExchangeApi.Application.Profiles;

public class ExchangeRateProfile : Profile
{
    public ExchangeRateProfile() 
    {
        CreateMap<ExchangeRate, ExchangeRateDto>();
        CreateMap<ExchangeRateDto, ExchangeRate>();
        CreateMap<AddExchangeRateDto, ExchangeRate>();
        CreateMap<ExchangeRate, AddExchangeRateDto>();

        CreateMap<bool, ExchangeRate>()
          .ConvertUsing(src => src ? new ExchangeRate() : null);
    }
}
