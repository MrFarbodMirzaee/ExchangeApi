using ExchangeApi.Contract;
using ExChangeApi.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ExChangeApi.Business;

public class CurrencyBusiness : ICurrencyBusiness
{
    static public List<Currency> currencies = new List<Currency>() 
    {
        new Currency() {Id = 1 ,Name = "Us Doller",CurrencyCode = "USD", IsActive = true, Created = DateTime.Now },
        new Currency() {Id = 2 ,Name = "Euro",CurrencyCode = "EUR", IsActive = true, Created = DateTime.Now },
        new Currency() {Id = 3 ,Name = "Biritish Pound",CurrencyCode = "GBP", IsActive = true, Created = DateTime.Now },
        new Currency() {Id = 4 ,Name = "Japanese yen",CurrencyCode = "JPY", IsActive = false, Created = DateTime.Now },
        new Currency() {Id = 5 ,Name = "Iranian Rial",CurrencyCode = "IRR", IsActive = true, Created = DateTime.Now }
    };
    public bool CreateCurrency(Currency currency)
    {
        currencies.Add(currency);
        return true;
    }

    public bool DeleteCurrency(int currencyId)
    {
        throw new NotImplementedException();
    }

    public List<Currency> GetAllActiveCurrencies()
    {
        return currencies.Where(c => c.IsActive.Equals(true)).ToList();
    }

    public Currency GetCurrencyById(int currencyId)
    {
        var currency = currencies.Where(x => x.Id == currencyId).FirstOrDefault();
        return currency;
    }

    public List<Currency> GetPopularCurrencies()
    {
       // The GetPopularCurrencies method filters the currencies list to include only currencies that have IsActive set to true, considering them as popular currencies.
        List<Currency> popularCurrencies = currencies.Where(c => c.IsActive).ToList();

        return popularCurrencies;
    }

    public List<Currency> SearchCurrencies(string keyword)
    {
        //It searches for currencies where the currency name or currency code contains the specified keyword (case-insensitive).
        List<Currency> result = currencies.Where(c => c.Name.ToLower().Contains(keyword.ToLower()) || c.CurrencyCode.ToLower().Contains(keyword.ToLower())).ToList();

        return result;
    }

    public bool UpdateCurrency(Currency currency)
    {
        throw new NotImplementedException();
    }
}
