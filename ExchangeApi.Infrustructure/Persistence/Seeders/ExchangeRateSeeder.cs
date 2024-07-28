using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeApi.Infrustructure.Persistence.Seeders;

public class ExchangeRateSeeder
{
    public static void Intialize(IServiceProvider service)
    {
        using (var context = new ApplicationDbContext(service.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            if (!context.ExchangeRate.Any())
            {
                context.ExchangeRate.AddRange(
                    new ExchangeRate
                    {
                        FromCurrency = 1,
                        IsActive = true,
                        ToCurrency = 2,
                        Rate = 0.85m,
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        Description = "Exchange rate from USD to EUR.",
                        MetaDescription = "Current exchange rate for USD to EUR.",
                        UpdatedByUserId = 1,
                        DeletedByUserId = 0
                    },
                    new ExchangeRate
                    {
                        FromCurrency = 2,
                        ToCurrency = 3,
                        IsActive = true,
                        Rate = 130.0m,
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        Description = "Exchange rate from EUR to JPY.",
                        MetaDescription = "Current exchange rate for EUR to JPY.",
                        UpdatedByUserId = 1,
                        DeletedByUserId = 0
                    },
                    new ExchangeRate
                    {
                        FromCurrency = 3,
                        ToCurrency = 1,
                        IsActive = false,
                        Rate = 0.0091m,
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        Description = "Exchange rate from JPY to USD.",
                        MetaDescription = "Current exchange rate for JPY to USD.",
                        UpdatedByUserId = 1,
                        DeletedByUserId = 0
                    });
                };

                context.SaveChanges();
            }
        }
    }
   
