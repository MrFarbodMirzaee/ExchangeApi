#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries.GetExchangeTransactionByCurrencyPair;

public record GetExchangeTransactionByCurrencyPairQuery : IRequest<Response<List<ExchangeTransactionDto>>>
{
    public Guid FromCurrency { get; set; }
    public Guid ToCurrency { get; set; }
}