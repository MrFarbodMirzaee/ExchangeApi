using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeApi.Infrustructure.Persistence.Seeders;

public class ExchangeTransactionSeeder
{
    public static void Intialize(IServiceProvider service)
    {
        using (var context = new AppDbContext(service.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if (!context.ExchangeTransaction.Any())
            {
                // List to hold exchange transactions
                var transactions = new List<ExchangeTransaction>();

                // Add dynamic ExchangeTransaction data
                for (int i = 1; i <= 100; i++) // Add 100 transactions
                {
                    transactions.Add(new ExchangeTransaction
                    {
                        FromCurrencyId = i % 10 + 1, // Assuming you have at least 10 currencies
                        ToCurrencyId = (i + 1) % 10 + 1, // Alternate between currencies
                        Amount = 100.00m + (i * 5), // Increase the amount dynamically
                        ResultAmount = (i % 2 == 0) ? (100.00m + (i * 5)) * 0.85m : (100.00m + (i * 5)) * 0.75m, // Randomly simulate result amount
                        ExChangeRateId = i % 3 + 1, // Cycle through exchange rate ids
                        TransactionDate = DateTime.Now.AddMinutes(-i), // Stagger transaction dates
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        Description = $"Transaction {i} from Currency {i % 10 + 1} to Currency {(i + 1) % 10 + 1}.",
                        MetaDescription = $"Exchange of {100.00m + (i * 5)} from Currency {i % 10 + 1} to Currency {(i + 1) % 10 + 1}.",
                        UserId = 1
                    });
                }

                // Save all exchange transactions
                context.ExchangeTransaction.AddRange(transactions);
                context.SaveChanges();
            }
        }
    }
}
