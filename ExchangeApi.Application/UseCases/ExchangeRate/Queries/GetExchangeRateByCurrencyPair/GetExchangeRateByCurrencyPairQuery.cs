#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetExchangeRateByCurrencyPair;

public record GetExchangeRateByCurrencyPairQuery : IRequest<Response<List<ExchangeRateDto>>>
{
    public Guid FromCurrency { get; set; }
    public Guid ToCurrency { get; set; }
}