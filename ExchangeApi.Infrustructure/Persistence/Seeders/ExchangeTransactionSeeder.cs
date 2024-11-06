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
                context.ExchangeTransaction.AddRange(
                new ExchangeTransaction
                {
                    FromCurrencyId = 1,
                    ToCurrencyId = 2,
                    Amount = 100.00m,
                    ResultAmount = 85.00m,
                    ExChangeRateId = 1,
                    TransactionDate = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Description = "Transaction from USD to EUR.",
                    MetaDescription = "Exchange of 100 USD to EUR.",
                    UserId = 1
                },
                new ExchangeTransaction
                {
                    FromCurrencyId = 2,
                    ToCurrencyId = 3,
                    Amount = 50.00m,
                    ResultAmount = 6500.00m,
                    ExChangeRateId = 2,
                    TransactionDate = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Description = "Transaction from EUR to JPY.",
                    MetaDescription = "Exchange of 50 EUR to JPY.",
                    UserId = 1
                },
                new ExchangeTransaction
                {
                    FromCurrencyId = 3,
                    ToCurrencyId = 1,
                    Amount = 1000.00m,
                    ResultAmount = 9.10m,
                    ExChangeRateId = 3,
                    TransactionDate = DateTime.Now,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Description = "Transaction from JPY to USD.",
                    MetaDescription = "Exchange of 1000 JPY to USD.",
                    UserId = 1
                });
            };
            context.SaveChanges();
        }
    }
}
