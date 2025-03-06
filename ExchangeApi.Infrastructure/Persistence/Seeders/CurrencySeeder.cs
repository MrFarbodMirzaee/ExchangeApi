using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeApi.Infrastructure.Persistence.Seeders;

public class CurrencySeeder
{
    public static async Task Initialize(IServiceProvider service)
    {
        await using var context = new AppDbContext(service.GetRequiredService<DbContextOptions<AppDbContext>>());
        if (!context.Currency.Any())
        {
            var currencies = new List<Currency>();
            for (int i = 0; i <= 100; i++)
            {
                currencies.Add(new Currency
                {
                    Id = Guid.NewGuid(),
                    CurrencyCode = "CUR",
                    Name = $"Currency {i}",
                    Created = DateTime.Now,
                    IsActive = i % 2 == 0,
                    ImagePath = $"/images/currencies/cur{i:D3}.png",
                    Updated = DateTime.Now,
                    Description = $"This is currency number {i}.",
                    MetaDescription = $"CUR{i:D3} - Description for Currency {i}.",
                    DeletedByUserId = Guid.NewGuid(),
                    UpdatedByUserId = Guid.NewGuid()
                });
            }

            context.Currency.AddRange(currencies);
            await context.SaveChangesAsync();
        }
    }
}