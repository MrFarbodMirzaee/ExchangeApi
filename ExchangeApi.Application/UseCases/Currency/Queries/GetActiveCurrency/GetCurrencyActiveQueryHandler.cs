using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetActiveCurrency;

public class GetCurrencyActiveQueryHandler(ICurrencyService currencyService, IMapper mapper)
    : IRequestHandler<GetCurrencyActiveQuery, Response<List<CurrencyDto>>>
{
    public async Task<Response<List<CurrencyDto>>> Handle(GetCurrencyActiveQuery request, CancellationToken ct)
    {
        Response<List<Domain.Entities.Currency>> currencyFind =
            await currencyService.FindByCondition(x => x.IsActive == true, ct);

        var currencies = mapper.Map<List<CurrencyDto>>(currencyFind.Data);
        return currencyFind.Succeeded
            ? new Response<List<CurrencyDto>>(currencies)
            : new Response<List<CurrencyDto>>(currencyFind.Message);
    }
}