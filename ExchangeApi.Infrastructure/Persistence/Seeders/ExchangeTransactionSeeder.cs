using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeApi.Infrastructure.Persistence.Seeders;

public class ExchangeTransactionSeeder
{
    public static async Task Initialize(IServiceProvider service)
    {
        await using var context = new AppDbContext(service.GetRequiredService<DbContextOptions<AppDbContext>>());
        if (!context.ExchangeTransaction.Any())
        {
            var user = await context.User.FirstOrDefaultAsync(); 
            
            if (user == null)
            {
                throw new Exception("No user found in the database. Run UserSeeder first.");
            }

            var userId = user.Id; // Retrieve the ID dynamically
            var transactions = new List<ExchangeTransaction>();

            for (int i = 1; i <= 100; i++)
            {
                transactions.Add(new ExchangeTransaction
                {
                    Id = Guid.NewGuid(),
                    FromCurrencyId = Guid.NewGuid(),
                    ToCurrencyId = Guid.NewGuid(),
                    Amount = 100.00m + (i * 5),
                    ResultAmount = (i % 2 == 0) ? (100.00m + (i * 5)) * 0.85m : (100.00m + (i * 5)) * 0.75m,
                    ExChangeRateId = Guid.NewGuid(),
                    TransactionDate = DateTime.Now.AddMinutes(-i),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Description = $"Transaction {i} from Currency {i % 10 + 1} to Currency {(i + 1) % 10 + 1}.",
                    MetaDescription =
                        $"Exchange of {100.00m + (i * 5)} from Currency {i % 10 + 1} to Currency {(i + 1) % 10 + 1}.",
                    UserId = userId
                });
            }

            context.ExchangeTransaction.AddRange(transactions);
            await context.SaveChangesAsync();
        }
    }
}