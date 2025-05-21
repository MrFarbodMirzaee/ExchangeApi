using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries.SearchCurrency;

public class SearchCurrencyQueryHandler(ICurrencyService currencyService, IMapper mapper)
    : IRequestHandler<SearchCurrencyQuery, Response<List<CurrencyDto>>>
{
    public async Task<Response<List<CurrencyDto>>> Handle(SearchCurrencyQuery request, CancellationToken ct)
    {
        Response<List<Domain.Entities.Currency>> currency =
            await currencyService.DynamicSearchCurrencyAsync(request, ct);
        
        var currencies = mapper
            .Map<List<CurrencyDto>>
            (currency.Data);
        
        return currency.Succeeded
            ? new Response<List<CurrencyDto>>(currencies)
            : new Response<List<CurrencyDto>>(currency.Message);
    }
}