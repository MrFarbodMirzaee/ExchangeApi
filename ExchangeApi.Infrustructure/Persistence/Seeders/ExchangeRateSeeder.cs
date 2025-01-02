using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeApi.Infrustructure.Persistence.Seeders;

public class ExchangeRateSeeder
{
    public static void Intialize(IServiceProvider service)
    {
        using (var context = new AppDbContext(service.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if (!context.ExchangeRate.Any())
            {
                // List to hold exchange rates
                var exchangeRates = new List<ExchangeRate>();

                // Add dynamic ExchangeRate data (e.g., for 10 different currencies)
                for (int i = 1; i <= 100; i++) // Assuming 10 currencies, adjust the range as needed
                {
                    exchangeRates.Add(new ExchangeRate
                    {
                        FromCurrency = i, // From currency ID
                        ToCurrency = (i % 10) + 1, // To currency ID, wraps around after 10
                        IsActive = i % 2 == 0, // Alternate between active and inactive
                        Rate = (decimal)(1 + (i * 0.1)), // Dynamic rate, adjust as needed
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        Description = $"Exchange rate from Currency {i} to Currency {(i % 10) + 1}.",
                        MetaDescription = $"Current exchange rate for Currency {i} to Currency {(i % 10) + 1}.",
                        UpdatedByUserId = 1, // Assuming User ID 1 is the updater
                        DeletedByUserId = 0 // Assuming no user deleted
                    });
                }

                // Save all exchange rates
                context.ExchangeRate.AddRange(exchangeRates);
                context.SaveChanges();
            }
        }
    }
}
