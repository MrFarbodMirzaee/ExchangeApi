﻿
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries;

public record GetAllExchangeTransactionQuery : IRequest<Response<List<ExchangeTransactionDto>>>
{

}