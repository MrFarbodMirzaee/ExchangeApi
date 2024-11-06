using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExChangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeApi.Infrustructure.Persistence.Seeders;
public class CurrencySeeder
{
    public static void Intialize(IServiceProvider service)
    {
        using (var context = new AppDbContext(service.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if (!context.Currency.Any())
            {
                context.Currency.AddRange(
                new Currency
                {
                    CurrencyCode = "USD",
                    Name = "United States Dollar",
                    Created = DateTime.Now,
                    IsActive = true,
                    ImagePath = "/images/currencies/usd.png",
                    Updated = DateTime.Now,
                    Description = "The official currency of the United States.",
                    MetaDescription = "USD - United States Dollar, the most widely used currency in the world.",
                    DeletedByUserId = 0,
                    UpdatedByUserId = 1
                },
                new Currency
                {
                    CurrencyCode = "EUR",
                    Name = "Euro",
                    Created = DateTime.Now,
                    IsActive = false,
                    ImagePath = "/images/currencies/eur.png",
                    Updated = DateTime.Now,
                    Description = "The official currency of the Eurozone.",
                    MetaDescription = "EUR - Euro, used by 19 of the 27 European Union countries.",
                    DeletedByUserId = 0,
                    UpdatedByUserId = 1
                },
                new Currency
                {
                    CurrencyCode = "JPY",
                    Name = "Japanese Yen",
                    Created = DateTime.Now,
                    ImagePath = "/images/currencies/jpy.png",
                    Updated = DateTime.Now,
                    IsActive = true,
                    Description = "The official currency of Japan.",
                    MetaDescription = "JPY - Japanese Yen, the currency of Japan.",
                    DeletedByUserId = 0,
                    UpdatedByUserId = 1
                });
                context.SaveChanges();
            }
        }
    }
}
