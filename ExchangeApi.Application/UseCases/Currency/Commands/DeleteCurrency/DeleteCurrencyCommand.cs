#nullable disable
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands.DeleteCurrency;

public record DeleteCurrencyCommand : IRequest<Response<bool>>
{
    public Guid CurrencyId { get; set; }
}