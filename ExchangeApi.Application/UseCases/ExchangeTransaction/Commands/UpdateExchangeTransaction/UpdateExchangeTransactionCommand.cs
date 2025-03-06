#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.UpdateExchangeTransaction;

public record UpdateExchangeTransactionCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public UpdateExchangeTransactionDto UpdateExchangeTransactionDto { get; set; }
}