using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeApi.Infrastructure.Persistence.Seeders;

public class ExchangeRateSeeder
{
    public static async Task Initialize(IServiceProvider service)
    {
        await using var context = new AppDbContext(service.GetRequiredService<DbContextOptions<AppDbContext>>());
        if (!context.ExchangeRate.Any())
        {
            var exchangeRates = new List<ExchangeRate>();
            for (int i = 1; i <= 100; i++)
            {
                exchangeRates.Add(new ExchangeRate
                {
                    Id = Guid.NewGuid(),
                    FromCurrencyId = Guid.NewGuid(),
                    ToCurrencyId = Guid.NewGuid(),
                    IsActive = i % 2 == 0,
                    Rate = (decimal)(1 + (i * 0.1)),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    MetaDescription = $"Current exchange rate for Currency {i} to Currency {(i % 10) + 1}.",
                    UpdatedByUserId = Guid.NewGuid(),
                    DeletedByUserId = Guid.NewGuid()
                });
            }

            context.ExchangeRate.AddRange(exchangeRates);
            await context.SaveChangesAsync();
        }
    }
}