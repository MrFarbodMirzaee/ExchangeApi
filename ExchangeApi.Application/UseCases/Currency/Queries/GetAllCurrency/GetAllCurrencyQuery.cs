#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.ValueObjects;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetAllCurrency;

public record GetAllCurrencyQuery : IRequest<Response<List<CurrencyDto>>>
{
    public QueryCriteria QueryCriteria { get; set; }
}