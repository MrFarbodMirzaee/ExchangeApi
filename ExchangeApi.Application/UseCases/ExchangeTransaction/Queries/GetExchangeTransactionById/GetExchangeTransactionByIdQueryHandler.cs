﻿using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries.GetExchangeTransactionById;

public class GetExchangeTransactionByIdQueryHandler(
    IExchangeTransactionServices exchangeTransactionServices,
    IMapper mapper)
    : IRequestHandler<GetExchangeTransactionByIdQuery, Response<List<ExchangeTransactionDto>>>
{
    public async Task<Response<List<ExchangeTransactionDto>>> Handle(GetExchangeTransactionByIdQuery request,
        CancellationToken ct)
    {
        Response<List<ExchangeApi.Domain.Entities.ExchangeTransaction>> exchangeTransactions =
            await exchangeTransactionServices.FindByCondition(x => x.Id == request.ExchangeTransactionId, ct);

        var exchangeTransactionMapped = mapper.Map<List<ExchangeTransactionDto>>(exchangeTransactions.Data);

        return exchangeTransactions.Succeeded
            ? new Response<List<ExchangeTransactionDto>>(exchangeTransactionMapped)
            : new Response<List<ExchangeTransactionDto>>(exchangeTransactions.Message);
    }
}