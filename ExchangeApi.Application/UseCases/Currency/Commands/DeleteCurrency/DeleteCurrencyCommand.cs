#nullable disable

using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands;

public record DeleteCurrencyCommand : IRequest<Response<int>>
{
    public int CurrenvyId { get; set; }
}
