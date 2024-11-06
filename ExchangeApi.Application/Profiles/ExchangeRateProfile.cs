using AutoMapper;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Application.UseCases.ExchangeRate.Commands;

namespace ExchangeApi.Application.Profiles;
public class ExchangeRateProfile : Profile
{
    public ExchangeRateProfile()
    {
        CreateMap<Response<List<ExchangeRate>>, List<ExchangeRateDto>>();
        CreateMap<Response<ExchangeRate>, ExchangeRateDto>();
        CreateMap<Response<List<ExchangeApi.Domain.Entities.ExchangeRate>>, Response<ExchangeApi.Application.Dtos.ExchangeRateDto>>();

        CreateMap<ExchangeRate, ExchangeRateDto>();
        CreateMap<ExchangeRateDto, ExchangeRate>();
        CreateMap<AddExchangeRateDto, ExchangeRate>();
        CreateMap<ExchangeRate, AddExchangeRateDto>();
        CreateMap<AddExchagneRateCommand, ExchangeRate>();

        CreateMap<bool, ExchangeRate>()
          .ConvertUsing(src => src ? new ExchangeRate() : null);
    }
}
