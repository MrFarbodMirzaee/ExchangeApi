﻿using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetExchangeRateByCurrencyPair;

public class GetExchangeRateByCurrencyPairQueryHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    : IRequestHandler<GetExchangeRateByCurrencyPairQuery, Response<List<ExchangeRateDto>>>
{
    public async Task<Response<List<ExchangeRateDto>>> Handle(GetExchangeRateByCurrencyPairQuery request,
        CancellationToken ct)
    {
        Response<List<ExchangeApi.Domain.Entities.ExchangeRate>> exchangeRate =
            await exchangeRateService.FindByCondition(
                e => e.FromCurrency == request.FromCurrency && e.ToCurrency == request.ToCurrency, ct);

        var exchangeRatesMapped = mapper.Map<List<ExchangeRateDto>>(exchangeRate.Data);
        return exchangeRate.Succeeded
            ? new Response<List<ExchangeRateDto>>(exchangeRatesMapped)
            : new Response<List<ExchangeRateDto>>(exchangeRate.Message);
    }
}