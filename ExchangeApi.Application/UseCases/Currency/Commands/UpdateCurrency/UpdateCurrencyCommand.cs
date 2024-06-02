#nullable disable

using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands;

public record UpdateCurrencyCommand : IRequest<Response<int>>
{
    public int CurrencyId { get; set; }
    public ExChangeApi.Domain.Entities.Currency Currency { get; set; }
}
