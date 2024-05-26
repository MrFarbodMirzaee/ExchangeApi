using ExchangeApi.Infrustructure.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Wrappers;
using ExChangeApi.Domain.Entities;
using ExchangeApi.Infrustructure.Persistence.Services;

namespace ExchangeApi.Infrustructure.Services;

public class ExchangeRateServices : GengericRepository<ExchangeRate>, IExchangeRateService
{
    private readonly ApplicationDbContext _context;
    public ExchangeRateServices(ApplicationDbContext context) : base(context) 
    {
        _context = context;
    }
  

    //public async Task<Response<ExchangeRate>> GetExchangeRateById(int rateId)
    //{
    //    var exchangeRate = await _context.ExchangeRate.Where(x => x.Id == rateId).AsNoTracking().FirstOrDefaultAsync();
    //    return new Response<ExchangeRate>(exchangeRate);
    //}

    //public async Task<Response<List<ExchangeRate>>> GetExchangeRatesByCurrencyPair(int fromCurrencyId, int toCurrencyId)
    //{
    //    //The GetExchangeRatesByCurrencyPair method filters the exchangeRates list to find exchange rates that match the given pair of fromCurrencyId and toCurrencyId
    //    List<ExchangeRate> result = await _context.ExchangeRate.Where(e => e.FromCurrency == fromCurrencyId && e.ToCurrency == toCurrencyId).AsNoTracking().ToListAsync();
    //    return new Response<List<ExchangeRate>>(result);
    //}

    //public async Task<Response<ExchangeRate>> GetLatestExchangeRate(int fromCurrencyId, int toCurrencyId)
    //{
    //    //The GetLatestExchangeRate method filters the exchangeRates list to find the exchange rate for the given pair of fromCurrencyId and toCurrencyId.
    //    // It then orders the filtered rates by LastUpdate in descending order to get the latest exchange rate.
    //    //Finally, it returns the latest exchange rate for the specified currency pair.
    //    ExchangeRate latestRate = await _context.ExchangeRate
    //    .Where(e => e.FromCurrency == fromCurrencyId && e.ToCurrency == toCurrencyId)
    //    .OrderByDescending(e => e.Updated)
    //    .AsNoTracking()
    //    .FirstOrDefaultAsync();
    //    return new Response<ExchangeRate>(latestRate);
    //}

}
