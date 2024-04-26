using ExChangeApi.Domain.Entities;

namespace ExchangeApi.Application.Contracts;

public interface ICurrencyService
{
    Task<List<Currency>> GetAllActiveCurrencies();
    Task<Currency> GetCurrencyById(int currencyId);
    Task<bool> CreateCurrency(Currency currency);
    Task<bool> UpdateCurrency(Currency currency);
    Task<bool> DeleteCurrency(int currencyId);
    Task<List<Currency>> SearchCurrencies(string keyword);
    Task<List<Currency>> GetPopularCurrencies();
    Task<bool> Activate(int currencyId);
}
