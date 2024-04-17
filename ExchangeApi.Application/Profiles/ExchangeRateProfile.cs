using AutoMapper;
using ExchangeApi.Domain.Entitiess;
using ExchangeApi.Application.Dtos;


namespace ExchangeApi.Application.Profiles;

public class ExchangeRateProfile : Profile
{
    public ExchangeRateProfile() 
    {
        CreateMap<ExchangeRate, ExchangeRateDto>();
        CreateMap<ExchangeRateDto, ExchangeRate>();
        CreateMap<List<ExchangeRate>, ExchangeRate>();
        CreateMap<ExchangeRate, List<ExchangeRate>>();
        CreateMap<List<ExchangeRateDto>, ExchangeRate>();
        CreateMap<ExchangeRate, List<ExchangeRateDto>>();
        CreateMap<ExchangeRate, List<ExchangeRate>>();
        CreateMap<AddExchangeRateDto, ExchangeRate>();
        CreateMap<ExchangeRate, AddExchangeRateDto>();
        CreateMap<List<AddExchangeRateDto>, ExchangeRate>();
        CreateMap<List<ExchangeRate>, AddCurencyDto>();
        CreateMap<bool, ExchangeRate>()
          .ConvertUsing(src => src ? new ExchangeRate() : null);
    }
}
