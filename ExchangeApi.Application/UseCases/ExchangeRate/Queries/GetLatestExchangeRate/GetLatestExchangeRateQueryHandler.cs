﻿using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetLatestExchangeRate;

public class GetLatestExchangeRateQueryHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    : IRequestHandler<GetLatestExchangeRateQuery, Response<List<ExchangeRateDto>>>
{
    public async Task<Response<List<ExchangeRateDto>>> Handle(GetLatestExchangeRateQuery request, CancellationToken ct)
    {
        Response<List<ExchangeApi.Domain.Entities.ExchangeRate>> exchangeRate =
            await exchangeRateService.FindByCondition(
                e => e.FromCurrencyId == request.FromCurrency
                     && e.ToCurrencyId == request.ToCurrency, ct);
        
        if (exchangeRate.Data is null)
            return new Response<List<ExchangeRateDto>>(exchangeRate.Message);

        var orderByDesc = exchangeRate.Data.OrderByDescending(e => e.Created);

        var exchangeRateMapped = mapper.Map<List<ExchangeRateDto>>(orderByDesc);
        
        return exchangeRate.Succeeded
            ? new Response<List<ExchangeRateDto>>(exchangeRateMapped)
            : new Response<List<ExchangeRateDto>>(exchangeRate.Message);
    }
}