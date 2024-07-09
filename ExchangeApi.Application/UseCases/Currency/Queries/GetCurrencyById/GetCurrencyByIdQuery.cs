#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries;

public record GetCurrencyByIdQuery : IRequest<Response<List<CurrencyDto>>>
{
    public int CurrencyId { get; set; }
}
