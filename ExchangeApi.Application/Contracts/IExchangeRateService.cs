using ExchangeApi.Domain.Entities;



namespace ExchangeApi.Application.Contracts;

public interface IExchangeRateService
{
    Task<List<ExchangeRate>> GetAllExchangeRates();
    Task<ExchangeRate> GetExchangeRateById(int rateId);
    Task<bool> CreateExchangeRate(ExchangeRate rate);
    Task<bool> UpdateExchangeRate(ExchangeRate rate);
    Task<bool> DeleteExchangeRate(int rateId);
    Task<List<ExchangeRate>> GetExchangeRatesByCurrencyPair(int fromCurrencyId, int toCurrencyId);
    Task<ExchangeRate> GetLatestExchangeRate(int fromCurrencyId, int toCurrencyId);
}
