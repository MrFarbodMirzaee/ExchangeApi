using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Contracts;



namespace ExchangeApi.Application.Contracts;

public interface IExchangeRateService : IGenericRepository<ExchangeRate>
{
    
    //Task<Response<ExchangeRate>> GetExchangeRateById(int rateId);
    // Task<Response<List<ExchangeRate>>> GetExchangeRatesByCurrencyPair(int fromCurrencyId, int toCurrencyId);
   // Task<Response<ExchangeRate>> GetLatestExchangeRate(int fromCurrencyId, int toCurrencyId);
}
