using AutoMapper;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Application.UseCases.Currency.Commands.AddCurrency;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Wrappers;

namespace ExchangeApi.Application.Profiles.Currency;

public class CurrencyProfile : Profile
{
    public CurrencyProfile()
    {
        #region CurrencyAttribute

        CreateMap<AddCurrencyAttributeDto, CurrencyAttribute>();
        CreateMap<CurrencyAttribute, AddCurrencyAttributeDto>();

        #endregion

        #region Currency

        CreateMap<Response<List<Domain.Entities.Currency>>, List<CurrencyDto>>();
        CreateMap<Response<Domain.Entities.Currency>, CurrencyDto>();
        CreateMap<List<CurrencyDto>, Domain.Entities.Currency>();
        CreateMap<List<CurrencyDto>, Domain.Entities.Currency>();
        CreateMap<List<Domain.Entities.Currency>, CurrencyDto>();
        CreateMap<Domain.Entities.Currency, List<CurrencyDto>>();
        CreateMap<CurrencyDto, Domain.Entities.Currency>();
        CreateMap<Domain.Entities.Currency, CurrencyDto>();
        CreateMap<AddCurrencyDto, Domain.Entities.Currency>();
        CreateMap<Domain.Entities.Currency, AddCurrencyDto>();
        CreateMap<UpdateCurrencyDto, Domain.Entities.Currency>();
        CreateMap<Domain.Entities.Currency, UpdateCurrencyDto>();
        #endregion

        CreateMap<AddCurrencyCommand, Domain.Entities.Currency>();
        CreateMap<bool, Domain.Entities.Currency>()
            .ConvertUsing(src => (src ? new Domain.Entities.Currency() : null)!);
    }
}