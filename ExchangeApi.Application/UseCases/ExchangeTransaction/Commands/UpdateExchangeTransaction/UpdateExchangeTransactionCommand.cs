#nullable disable
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands;

public record UpdateExchangeTransactionCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public ExchangeApi.Domain.Entitiess.ExchangeTransaction ExchangeTransaction { get; set; }
}
