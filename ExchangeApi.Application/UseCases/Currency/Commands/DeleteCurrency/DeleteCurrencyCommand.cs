#nullable disable
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands;
public record DeleteCurrencyCommand : IRequest<Response<bool>>
{
    public int CurrencyId { get; set; }
}
