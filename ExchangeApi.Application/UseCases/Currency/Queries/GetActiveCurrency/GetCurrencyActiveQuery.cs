using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetActiveCurrency;

public record GetCurrencyActiveQuery : IRequest<Response<List<CurrencyDto>>>
{
}

