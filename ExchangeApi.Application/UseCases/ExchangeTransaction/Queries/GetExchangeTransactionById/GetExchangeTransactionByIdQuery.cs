#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries;

public record GetExchangeTransactionByIdQuery : IRequest<Response<ExchangeTransactionDto>>
{
    public int ExTId { get; set; }
}
