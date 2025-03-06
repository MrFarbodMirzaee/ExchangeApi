#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands.UpdateCurrency;

public record UpdateCurrencyCommand : IRequest<Response<bool>>
{
    public Guid CurrencyId { get; set; }
    public UpdateCurrencyDto UpdateCurrencyDto { get; set; }
}