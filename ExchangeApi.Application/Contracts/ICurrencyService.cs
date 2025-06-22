using ExchangeApi.Application.Dtos;
using ExchangeApi.Application.UseCases.Currency.Queries.GetCurrencyWithDetails;
using ExchangeApi.Application.UseCases.Currency.Queries.SearchCurrency;
using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Wrappers;

namespace ExchangeApi.Application.Contracts;

public interface ICurrencyService : IGenericRepository<Currency>
{
   Task<Response<List<Currency>>> DynamicSearchCurrencyAsync(SearchCurrencyQuery request, CancellationToken ct);
   Task<Response<CurrencyDetailDto>> GetCurrencyDetailsAsync(GetCurrencyWithDetailsQuery request,CancellationToken ct);
}