using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.ValueObjects;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries.GetAllExchangeTransaction;

public record GetAllExchangeTransactionQuery : IRequest<Response<List<ExchangeTransactionDto>>>
{
    public QueryCriteria QueryCriteria { get; set; }
}