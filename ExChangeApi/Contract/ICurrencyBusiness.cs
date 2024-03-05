using ExChangeApi.Models;

namespace ExchangeApi.Contract;

public interface ICurrencyBusiness
{
    List<Currency> GetAllActiveCurrencies();
    Currency GetCurrencyById(int currencyId);
    bool CreateCurrency(Currency currency);
    bool UpdateCurrency(Currency currency);
    bool DeleteCurrency(int currencyId);
    List<Currency> SearchCurrencies(string keyword);
    List<Currency> GetPopularCurrencies();
}
