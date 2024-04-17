using ExchangeApi.Application.Contracts;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExChangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExchangeApi.Infrustructure.Repository;

public class CurrencyService : ICurrencyService
{
    private readonly ApplicationDbContext _context;
    public CurrencyService(ApplicationDbContext context) => _context = context;

    public async Task<bool> CreateCurrency(Currency currency)
    {
         _context.Currency.Add(currency);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCurrency(int currencyId)
    {
        var currency = _context.Currency.FirstOrDefault(x => x.Id == currencyId);
        if (currency != null)
        {
             _context.Currency.Remove(currency);
            await _context.SaveChangesAsync();
            return true; // Assuming the deletion was successful
        }
        return false; // If the currency with the given ID doesn't exist
    }

    public async Task<List<Currency>> GetAllActiveCurrencies()
    {
        var currencies = await _context.Currency.Where(c => c.IsActive.Equals(true)).AsNoTracking().ToListAsync();
        return currencies;
    }

    public async Task<Currency> GetCurrencyById(int currencyId)
    {

        var currency = await _context.Currency.Where(x => x.Id == currencyId).AsNoTracking().FirstOrDefaultAsync();
        return currency;
    }

    public async Task<List<Currency>> GetPopularCurrencies()
    {
        // The GetPopularCurrencies method filters the currencies list to include only currencies that have IsActive set to true, considering them as popular currencies.
        List<Currency> popularCurrencies = await _context.Currency.AsNoTracking().ToListAsync();

        return popularCurrencies;
    }

    public async Task<List<Currency>> SearchCurrencies(string keyword)
    {
        //It searches for currencies where the currency name or currency code contains the specified keyword (case-insensitive).
        List<Currency> result = await _context.Currency.Where(c => c.Name.ToLower().Contains(keyword.ToLower()) || c.CurrencyCode.ToLower().Contains(keyword.ToLower())).AsNoTracking().ToListAsync();

        return result;
    }

    public async Task<bool> UpdateCurrency(Currency currency)
    {
        var existingCurrency = _context.Currency.FirstOrDefault(x => x.Id == currency.Id);
        if (existingCurrency != null)
        {
            existingCurrency.Name = currency.Name; // Update other properties as needed
            existingCurrency.CurrencyCode = currency.CurrencyCode;// Update other properties as needed
            existingCurrency.Updated = DateTime.Now;
            existingCurrency.IsActive = currency.IsActive;

            await  _context.SaveChangesAsync();
            return true; // Assuming the update was successful
        }
        return false; // If the currency with the given ID doesn't exist
    }
}
