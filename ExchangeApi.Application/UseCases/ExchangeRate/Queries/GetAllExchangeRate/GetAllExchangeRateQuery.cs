#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.ValueObjects;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetAllExchangeRate;

public record GetAllExchangeRateQuery : IRequest<Response<List<ExchangeRateDto>>>
{
    public QueryCriteria QueryCriteria { get; set; }
}