#nullable disable

using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands;

public record DeleteExchangeTransactionCommand : IRequest<Response<int>>
{
    public int ExTId { get; set; }
}
