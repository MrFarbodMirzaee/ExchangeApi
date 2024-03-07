using AutoMapper;
using ExchangeApi.Dtos;
using ExchangeApi.Models;


namespace ExchangeApi.Profiles;

public class ExchangeRateProfile : Profile
{
    public ExchangeRateProfile() 
    {
        CreateMap<ExchangeRate, ExchangeRateDto>();
        CreateMap<ExchangeRateDto, ExchangeRate>();
    }
}
