using ExchangeApi.Domain.Contracts;
using ExChangeApi.Domain.Entities;

namespace ExchangeApi.Infrustructure.Persistence.Seeder;

public class CurrencySeeder : IBaseSeeder<Currency>
{
    private readonly Currency _currency;

    public CurrencySeeder(Currency currency)
    {
        _currency = currency;
    }

    public IEnumerable<Currency> GetSeedData()
                => new List<Currency>()
            {
            new()
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
            new()
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
            new()
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
            },
    };
}
