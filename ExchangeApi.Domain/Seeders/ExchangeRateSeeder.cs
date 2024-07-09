using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Infrustructure.Persistence.Seeders;

public class ExchangeRateSeeder : IBaseSeeder<ExchangeRate>
{
    public IEnumerable<ExchangeRate> GetSeedData()
    {
        var exchangeRates = new List<ExchangeRate>
    {
        new ExchangeRate
        {
            Id = 1,
            FromCurrency = 1, // USD
            ToCurrency = 2, // EUR
            Rate = 0.85m,
            Created = DateTime.Now,
            Updated = DateTime.Now,
            Description = "Exchange rate between USD and EUR.",
            MetaDescription = "Current exchange rate for converting USD to EUR.",
            UpdatedByUserId = 1,
            DeletedByUserId = 0
        },
        new ExchangeRate
        {
            Id = 2,
            FromCurrency = 1, // USD
            ToCurrency = 3, // GBP
            Rate = 0.79m,
            Created = DateTime.Now,
            Updated = DateTime.Now,
            Description = "Exchange rate between USD and GBP.",
            MetaDescription = "Current exchange rate for converting USD to GBP.",
            UpdatedByUserId = 1,
            DeletedByUserId = 0
        },
        new ExchangeRate
        {
            Id = 3,
            FromCurrency = 2, // EUR
            ToCurrency = 3, // GBP
            Rate = 0.93m,
            Created = DateTime.Now,
            Updated = DateTime.Now,
            Description = "Exchange rate between EUR and GBP.",
            MetaDescription = "Current exchange rate for converting EUR to GBP.",
            UpdatedByUserId = 1,
            DeletedByUserId = 0
        }
    };

        foreach (var exchangeRate in exchangeRates)
        {
            exchangeRate.Activate();
        }

        exchangeRates.Single(er => er.Id == 2).Deactivate();

        return exchangeRates;
    }
}

