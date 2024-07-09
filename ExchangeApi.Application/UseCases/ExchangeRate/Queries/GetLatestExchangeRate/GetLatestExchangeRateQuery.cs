#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries;

public record GetLatestExchangeRateQuery : IRequest<Response<List<ExchangeRateDto>>>
{
    public int FromCurrency { get; set; }
    public int ToCurrency { get; set; }
}
