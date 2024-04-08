using ExchangeApi.Contexts;
using ExchangeApi.Contracts;
using ExChangeApi.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ExchangeApi.Servcies;

public class CurrencyService : ICurrencyService
{
    private readonly ApplicationDbContext _context;
    public CurrencyService(ApplicationDbContext context) => _context = context;

    public bool CreateCurrency(Currency currency)
    {
        _context.Currency.Add(currency);
        _context.SaveChanges();
        return true;
    }

    public bool DeleteCurrency(int currencyId)
    {
        var currency = _context.Currency.FirstOrDefault(x => x.Id == currencyId);
        if (currency != null)
        {
            _context.Currency.Remove(currency);
            _context.SaveChanges();
            return true; // Assuming the deletion was successful
        }
        return false; // If the currency with the given ID doesn't exist
    }

    public List<Currency> GetAllActiveCurrencies()
    {
        return _context.Currency.Where(c => c.IsActive.Equals(true)).ToList();
    }

    public Currency GetCurrencyById(int currencyId)
    {

        var currency = _context.Currency.Where(x => x.Id == currencyId).FirstOrDefault();
        return currency;
    }

    public List<Currency> GetPopularCurrencies()
    {
        // The GetPopularCurrencies method filters the currencies list to include only currencies that have IsActive set to true, considering them as popular currencies.
        List<Currency> popularCurrencies = _context.Currency.ToList();

        return popularCurrencies;
    }

    public List<Currency> SearchCurrencies(string keyword)
    {
        //It searches for currencies where the currency name or currency code contains the specified keyword (case-insensitive).
        List<Currency> result = _context.Currency.Where(c => c.Name.ToLower().Contains(keyword.ToLower()) || c.CurrencyCode.ToLower().Contains(keyword.ToLower())).ToList();

        return result;
    }

    public bool UpdateCurrency(Currency currency)
    {
        var existingCurrency = _context.Currency.FirstOrDefault(x => x.Id == currency.Id);
        if (existingCurrency != null)
        {
            existingCurrency.Name = currency.Name; // Update other properties as needed
            existingCurrency.CurrencyCode = currency.CurrencyCode;// Update other properties as needed
            existingCurrency.Updated = DateTime.Now;
            existingCurrency.IsActive = currency.IsActive;

            _context.SaveChanges();
            return true; // Assuming the update was successful
        }
        return false; // If the currency with the given ID doesn't exist
    }
}
