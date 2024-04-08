using ExchangeApi.Models;

namespace ExchangeApi.Contracts;

public interface IExchangeRateBusiness
{
    List<ExchangeRate> GetAllExchangeRates();
    ExchangeRate GetExchangeRateById(int rateId);
    bool CreateExchangeRate(ExchangeRate rate);
    bool UpdateExchangeRate(ExchangeRate rate);
    bool DeleteExchangeRate(int rateId);
    List<ExchangeRate> GetExchangeRatesByCurrencyPair(int fromCurrencyId, int toCurrencyId);
    ExchangeRate GetLatestExchangeRate(int fromCurrencyId, int toCurrencyId);
}
