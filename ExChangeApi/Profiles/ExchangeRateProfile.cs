using AutoMapper;
using ExchangeApi.Dtos;
using ExchangeApi.Models;
using ExChangeApi.Models;


namespace ExchangeApi.Profiles;

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
    }
}
