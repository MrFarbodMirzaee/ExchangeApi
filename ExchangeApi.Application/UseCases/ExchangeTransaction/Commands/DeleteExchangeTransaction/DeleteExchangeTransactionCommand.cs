#nullable disable
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.DeleteExchangeTransaction;

public record DeleteExchangeTransactionCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}