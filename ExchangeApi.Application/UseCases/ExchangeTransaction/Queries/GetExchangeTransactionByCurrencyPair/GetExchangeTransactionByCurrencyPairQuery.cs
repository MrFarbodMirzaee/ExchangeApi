﻿#nullable disable

using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries;

public record GetExchangeTransactionByCurrencyPairQuery : IRequest<Response<ExchangeTransactionDto>>
{
    public int FromCurrency { get; set; }
    public int ToCurrency { get; set; }
}