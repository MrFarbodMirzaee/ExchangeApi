using ExchangeApi.Domain.Contracts;


namespace ExchangeApi.Infrustructure.Persistence.Seeders;

public class CurrencySeeder : IBaseSeeder<ExChangeApi.Domain.Entities.Currency>
{
    public IEnumerable<ExChangeApi.Domain.Entities.Currency> GetSeedData()
    {
        var currencies = new List<ExChangeApi.Domain.Entities.Currency>
        {
            new ExChangeApi.Domain.Entities.Currency()
            {
                Id = 1,
                CurrencyCode = "USD",
                Name = "United States Dollar",
                Created = DateTime.Now,
                DeletedByUserId = 0,
                UpdatedByUserId = 1,
                ImagePath = "/images/usd.png",
                Updated = DateTime.Now,
                Description = "The official currency of the United States of America.",
                MetaDescription = "USD is the most widely traded currency in the world.",
            },
            new ExChangeApi.Domain.Entities.Currency()
            {
                Id = 2,
                CurrencyCode = "EUR",
                Name = "Euro",
                Created = DateTime.Now,
                DeletedByUserId = 0,
                UpdatedByUserId = 1,
                ImagePath = "/images/eur.png",
                Updated = DateTime.Now,
                Description = "The official currency of the European Union.",
                MetaDescription = "EUR is the second most widely traded currency in the world."
            },
            new ExChangeApi.Domain.Entities.Currency()
            {
                Id = 3,
                CurrencyCode = "GBP",
                Name = "British Pound Sterling",
                Created = DateTime.Now,
                DeletedByUserId = 0,
                UpdatedByUserId = 1,
                ImagePath = "/images/gbp.png",
                Updated = DateTime.Now,
                Description = "The official currency of the United Kingdom.",
                MetaDescription = "GBP is the third most widely traded currency in the world."
            }
        };
        foreach (var currency in currencies)
        {
            currency.Activate();
        }

        return currencies;
    }
}
