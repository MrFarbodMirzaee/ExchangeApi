using AutoMapper;
using ExchangeApi.Application.Attributes;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Application.UseCases.ExchangeRate.Commands.AddExchangeRate;
using ExchangeApi.Domain.Wrappers;

namespace ExchangeApi.Application.Profiles.ExchangeRate;

[Profile]
public class ExchangeRateProfile : Profile
{
    public ExchangeRateProfile()
    {
        CreateMap<Response<List<Domain.Entities.ExchangeRate>>, List<ExchangeRateDto>>();
        CreateMap<Response<Domain.Entities.ExchangeRate>, ExchangeRateDto>();
        CreateMap<Response<List<ExchangeApi.Domain.Entities.ExchangeRate>>,
            Response<ExchangeRateDto>>();

        CreateMap<Domain.Entities.ExchangeRate, ExchangeRateDto>();
        CreateMap<ExchangeRateDto, Domain.Entities.ExchangeRate>();
        CreateMap<AddExchangeRateDto, Domain.Entities.ExchangeRate>();
        CreateMap<Domain.Entities.ExchangeRate, AddExchangeRateDto>();
        CreateMap<AddExchangeRateCommand, Domain.Entities.ExchangeRate>();
        CreateMap<Domain.Entities.ExchangeRate, UpdateExchangeRateDto>();
        CreateMap<UpdateExchangeRateDto, Domain.Entities.ExchangeRate>();
        

        CreateMap<bool, Domain.Entities.ExchangeRate>()
            .ConvertUsing(src => (src ? new Domain.Entities.ExchangeRate() : null)!);
    }
}