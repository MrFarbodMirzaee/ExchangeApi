#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetAllCurrency;

public record GetAllCurrencyQuery : IRequest<Response<List<CurrencyDto>>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}