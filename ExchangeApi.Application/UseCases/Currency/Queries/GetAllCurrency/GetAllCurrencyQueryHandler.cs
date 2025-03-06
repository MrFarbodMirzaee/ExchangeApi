﻿using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetAllCurrency
{
    public class GetAllCurrencyQueryHandler(ICurrencyService currencyService, IMapper mapper)
        : IRequestHandler<GetAllCurrencyQuery, Response<List<CurrencyDto>>>
    {
        public async Task<Response<List<CurrencyDto>>> Handle(GetAllCurrencyQuery request, CancellationToken ct)
        {
            var pageSize = request.PageSize;
            var page = request.Page;
            Response<List<Domain.Entities.Currency>> currency = await currencyService.GetAllAsync(ct, page, pageSize);
            var currencyMapped = mapper.Map<List<CurrencyDto>>(currency.Data);
            return currency.Succeeded
                ? new Response<List<CurrencyDto>>(currencyMapped)
                : new Response<List<CurrencyDto>>(currency.Message);
        }
    }
}