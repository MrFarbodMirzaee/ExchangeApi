using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExChangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeApi.Infrustructure.Persistence.Seeders;

public class CurrencySeeder
{
    public static async void Intialize(IServiceProvider service)
    {
        using (var context = new AppDbContext(service.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if (!context.Currency.Any())
            {
                // List to hold currencies
                var currencies = new List<Currency>();
                // Add 100 currencies dynamically (starting from 0)
                for(int i = 0; i<=100 ; i++)
                {
                    currencies.Add(new Currency
                    {
                        CurrencyCode = "CUR", // Ensure CurrencyCode is 3 characters
                        Name = $"Currency {i}",
                        Created = DateTime.Now,
                        IsActive = i % 2 == 0,
                        ImagePath = $"/images/currencies/cur{i:D3}.png",
                        Updated = DateTime.Now,
                        Description = $"This is currency number {i}.",
                        MetaDescription = $"CUR{i:D3} - Description for Currency {i}.",
                        DeletedByUserId = 0,
                        UpdatedByUserId = 1
                    });

                }
                // Save all currencies
                context.Currency.AddRange(currencies);
                context.SaveChanges();
            }
        }
    }
}
