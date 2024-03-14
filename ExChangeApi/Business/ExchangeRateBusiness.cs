﻿using ExchangeApi.Contract;
using ExchangeApi.Models;
using ExChangeApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExChangeApi.Business;

public class ExchangeRateBusiness : IExchangeRateBusiness
{
    
    static public List<ExchangeRate> exchangeRates = new List<ExchangeRate>()
{
    new ExchangeRate()
    {
        Id = 1,
        FromCurrency = 1,
        ToCurrency = 2,
        Rate = 0.85m,
        LastUpdate = DateTime.Parse("2023-12-15 09:30:00"),
        Created = DateTime.Now,
        IsActive = true
    },
    new ExchangeRate()
    {
        Id = 2,
        FromCurrency = 2,
        ToCurrency = 1,
        Rate = 1.18m,
        LastUpdate = DateTime.Parse("2023-12-15 10:30:00"),
        Created = DateTime.Now,
        IsActive = true
    },
    new ExchangeRate()
    {
        Id = 3,
        FromCurrency = 3,
        ToCurrency = 2,
        Rate = 1.07m,
        LastUpdate = DateTime.Parse("2023-12-15 10:30:00"),
        Created = DateTime.Now,
        IsActive = true
    },
    new ExchangeRate()
    {
        Id = 4,
        FromCurrency = 2,
        ToCurrency = 3,
        Rate = 0.95m,
        LastUpdate = DateTime.Parse("2023-12-15 10:30:00"),
        Created = DateTime.Now,
        IsActive = true
    },
    new ExchangeRate()
    {
        Id = 5,
        FromCurrency = 3,
        ToCurrency = 4,
        Rate = 0.30m,
        LastUpdate = DateTime.Parse("2023-12-15 10:30:00"),
        Created = DateTime.Now,
        IsActive = true
    },
    new ExchangeRate()
    {
        Id = 6,
        FromCurrency = 4,
        ToCurrency = 3,
        Rate = 1.18m,
        LastUpdate = DateTime.Parse("2023-12-15 10:30:00"),
        Created = DateTime.Now,
        IsActive = true
    },
     new ExchangeRate()
    {
        Id = 7,
        FromCurrency = 5,
        ToCurrency = 4,
        Rate = 2.18m,
        LastUpdate = DateTime.Parse("2023-12-15 10:30:00"),
        Created = DateTime.Now,
        IsActive = true
     }
};


    public bool CreateExchangeRate(ExchangeRate rate)
    {
        exchangeRates.Add(rate);
        return true;
    }

    
    public List<ExchangeRate> GetAllExchangeRates()
    {
        return exchangeRates;
    }

    public ExchangeRate GetExchangeRateById(int rateId)
    {
        var exchangeRate = exchangeRates.Where(x => x.Id == rateId).FirstOrDefault();
        return exchangeRate;
    }

    public List<ExchangeRate> GetExchangeRatesByCurrencyPair(int fromCurrencyId, int toCurrencyId)
    {
        //The GetExchangeRatesByCurrencyPair method filters the exchangeRates list to find exchange rates that match the given pair of fromCurrencyId and toCurrencyId
        List<ExchangeRate> result = exchangeRates.Where(e => e.FromCurrency == fromCurrencyId && e.ToCurrency == toCurrencyId).ToList();
        return result;
    }

    public ExchangeRate GetLatestExchangeRate(int fromCurrencyId, int toCurrencyId)
    {
        //The GetLatestExchangeRate method filters the exchangeRates list to find the exchange rate for the given pair of fromCurrencyId and toCurrencyId.
        // It then orders the filtered rates by LastUpdate in descending order to get the latest exchange rate.
        //Finally, it returns the latest exchange rate for the specified currency pair.
        ExchangeRate latestRate = exchangeRates
        .Where(e => e.FromCurrency == fromCurrencyId && e.ToCurrency == toCurrencyId)
        .OrderByDescending(e => e.LastUpdate)
        .FirstOrDefault();
        return latestRate;
    }

  

    bool IExchangeRateBusiness.DeleteExchangeRate(int rateId)
    {
        throw new NotImplementedException();
    }

    bool IExchangeRateBusiness.UpdateExchangeRate(ExchangeRate rate)
    {
        throw new NotImplementedException();
    }
}
