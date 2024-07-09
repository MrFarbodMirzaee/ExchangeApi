using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Infrustructure.Persistence.Seeders;

public class ExchangeTransactionSeeder : IBaseSeeder<ExchangeTransaction>
{

    public IEnumerable<ExchangeTransaction> GetSeedData()
    {
        var exchangeTransactions = new List<ExchangeTransaction>
    {
        new ExchangeTransaction
        {
            Id = 1,
            FromCurrencyId = 1, // USD
            ToCurrencyId = 2, // EUR
            Amount = 1000.0m,
            ResultAmount = 850.0m,
            ExChangeRateId = 1,
            TransactionDate = DateTime.Now,
            Created = DateTime.Now,
            Updated = DateTime.Now,
            Description = "Exchange transaction from USD to EUR.",
            MetaDescription = "Exchanged 1000 USD for 850 EUR.",
            UserId = 1,
            UpdatedByUserId = 1,
            DeletedByUserId = 0
        },
        new ExchangeTransaction
        {
            Id = 2,
            FromCurrencyId = 1, // USD
            ToCurrencyId = 3, // GBP
            Amount = 500.0m,
            ResultAmount = 395.0m,
            ExChangeRateId = 2,
            TransactionDate = DateTime.Now.AddDays(-1),
            Created = DateTime.Now.AddDays(-1),
            Updated = DateTime.Now.AddDays(-1),
            Description = "Exchange transaction from USD to GBP.",
            MetaDescription = "Exchanged 500 USD for 395 GBP.",
            UserId = 2,
            UpdatedByUserId = 1,
            DeletedByUserId = 0
        },
        new ExchangeTransaction
        {
            Id = 3,
            FromCurrencyId = 2, // EUR
            ToCurrencyId = 3, // GBP
            Amount = 750.0m,
            ResultAmount = 697.5m,
            ExChangeRateId = 3,
            TransactionDate = DateTime.Now.AddDays(-2),
            Created = DateTime.Now.AddDays(-2),
            Updated = DateTime.Now.AddDays(-2),
            Description = "Exchange transaction from EUR to GBP.",
            MetaDescription = "Exchanged 750 EUR for 697.5 GBP.",
            UserId = 1,
            UpdatedByUserId = 1,
            DeletedByUserId = 0
        }
    };

        // Activate all exchange transactions
        foreach (var exchangeTransaction in exchangeTransactions)
        {
            exchangeTransaction.Activate();
        }

        // Deactivate the exchange transaction with Id = 2
        exchangeTransactions.Single(et => et.Id == 2).Deactivate();

        return exchangeTransactions;
    }
}
