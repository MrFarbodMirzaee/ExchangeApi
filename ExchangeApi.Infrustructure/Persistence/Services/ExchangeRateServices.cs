using ExchangeApi.Infrustructure.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Infrustructure.Services;

public class ExchangeRateServices : IExchangeRateService
{
    private readonly ApplicationDbContext _context;
    public ExchangeRateServices(ApplicationDbContext context) => _context = context;
    public async Task<bool> CreateExchangeRate(ExchangeRate rate)
    {
        _context.ExchangeRate.Add(rate);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<ExchangeRate>> GetAllExchangeRates()
    {
        List<ExchangeRate> data = await _context.ExchangeRate.AsNoTracking().ToListAsync();
        return data;
    }

    public async Task<ExchangeRate> GetExchangeRateById(int rateId)
    {
        var exchangeRate = await _context.ExchangeRate.Where(x => x.Id == rateId).AsNoTracking().FirstOrDefaultAsync();
        return exchangeRate;
    }

    public async Task<List<ExchangeRate>> GetExchangeRatesByCurrencyPair(int fromCurrencyId, int toCurrencyId)
    {
        //The GetExchangeRatesByCurrencyPair method filters the exchangeRates list to find exchange rates that match the given pair of fromCurrencyId and toCurrencyId
        List<ExchangeRate> result = await _context.ExchangeRate.Where(e => e.FromCurrency == fromCurrencyId && e.ToCurrency == toCurrencyId).AsNoTracking().ToListAsync();
        return result;
    }

    public async Task<ExchangeRate> GetLatestExchangeRate(int fromCurrencyId, int toCurrencyId)
    {
        //The GetLatestExchangeRate method filters the exchangeRates list to find the exchange rate for the given pair of fromCurrencyId and toCurrencyId.
        // It then orders the filtered rates by LastUpdate in descending order to get the latest exchange rate.
        //Finally, it returns the latest exchange rate for the specified currency pair.
        ExchangeRate latestRate = await _context.ExchangeRate
        .Where(e => e.FromCurrency == fromCurrencyId && e.ToCurrency == toCurrencyId)
        .OrderByDescending(e => e.Updated)
        .AsNoTracking()
        .FirstOrDefaultAsync();
        return latestRate;
    }



    public async Task<bool> DeleteExchangeRate(int rateId)
    {
        var currency = _context.ExchangeRate.FirstOrDefault(x => x.Id == rateId);
        if (currency != null) 
        {
             _context.ExchangeRate.Remove(currency);
             await _context.SaveChangesAsync();
            return true;
        }
        return false;

    }

    public async Task<bool> UpdateExchangeRate(ExchangeRate rate)
    {
        var exisitingExchangeRate = _context.ExchangeRate.FirstOrDefault(e => e.Id == rate.Id);
        if (exisitingExchangeRate != null)
        {
            exisitingExchangeRate.FromCurrency = rate.FromCurrency;
            exisitingExchangeRate.ToCurrency = rate.ToCurrency;
            exisitingExchangeRate.Rate = rate.Rate;
            exisitingExchangeRate.Updated = DateTime.Now;
            exisitingExchangeRate.IsActive = rate.IsActive;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public Task<bool> Activate(int exchangeRateId)
    {
        throw new NotImplementedException();
    }
}
