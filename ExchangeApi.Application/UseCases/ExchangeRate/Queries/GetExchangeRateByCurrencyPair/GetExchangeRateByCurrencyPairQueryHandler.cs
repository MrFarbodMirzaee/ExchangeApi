using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetExchangeRateByCurrencyPair;

public class GetExchangeRateByCurrencyPairQueryHandler(IExchangeRateService exchangeRateService,
    IValidator<GetExchangeRateByCurrencyPairQuery> getExchangeRateByCurrencyPairQueryValidator,
    IMapper mapper)
    : IRequestHandler<GetExchangeRateByCurrencyPairQuery, Response<List<ExchangeRateDto>>>
{
    public async Task<Response<List<ExchangeRateDto>>> Handle(GetExchangeRateByCurrencyPairQuery request,
        CancellationToken ct)
    {
        await getExchangeRateByCurrencyPairQueryValidator
        .ValidateAndThrowAsync(request,ct);
        
        Response<List<ExchangeApi.Domain.Entities.ExchangeRate>> exchangeRate =
            await exchangeRateService.FindByCondition(
                e => e.FromCurrencyId == request.FromCurrency 
                     && e.ToCurrencyId == request.ToCurrency, ct);

        var exchangeRatesMapped = mapper.Map<List<ExchangeRateDto>>(exchangeRate.Data);
        
        return exchangeRate.Succeeded
            ? new Response<List<ExchangeRateDto>>(exchangeRatesMapped)
            : new Response<List<ExchangeRateDto>>(exchangeRate.Message);
    }
}