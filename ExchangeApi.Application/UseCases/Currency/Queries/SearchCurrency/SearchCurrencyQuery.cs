using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries.SearchCurrency;

public record SearchCurrencyQuery : IRequest<Response<List<CurrencyDto>>>
{
    /// <summary>
    /// Represents the code that identifies the currency (e.g., USD, EUR).
    /// </summary>
    public string? CurrencyCode { get; set; }

    /// <summary>
    /// Represents the name of the currency (e.g., US Dollar, Euro).
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// A flag indicating whether the currency is currently active.
    /// </summary>
    public bool? IsActive { get; set; }
}