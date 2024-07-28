#nullable disable
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands;

public record DeleteCurrencyCommand : IRequest<Response<int>>
{
    public int CurrencyId { get; set; }
}
