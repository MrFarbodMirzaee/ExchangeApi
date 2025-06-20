﻿using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetAllCurrency;

public class GetAllCurrencyQueryHandler(ICurrencyService currencyService,
    IValidator<GetAllCurrencyQuery> getAllCurrencyQueryValidator,
    IMapper mapper)
    : IRequestHandler<GetAllCurrencyQuery, Response<List<CurrencyDto>>>
{
    public async Task<Response<List<CurrencyDto>>> Handle(GetAllCurrencyQuery request, CancellationToken ct)
    {
        await getAllCurrencyQueryValidator
        .ValidateAndThrowAsync(request,ct);
        
        var currency =
            await currencyService
                .FindByQueryCriteria(request.QueryCriteria, ct);

        var currencyMapped = mapper
            .Map<List<CurrencyDto>>
                (currency.Data);

        return currency.Succeeded
            ? new Response<List<CurrencyDto>>(currencyMapped)
            : new Response<List<CurrencyDto>>(currency.Message);
    }
}