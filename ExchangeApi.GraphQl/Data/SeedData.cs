using ExchangeApi.GraphQl.Enum;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.GraphQl.Data;

public class SeedData
{
    public static void Intialize(IServiceProvider service) 
    {
        using (var context = new AppDbContext(service.GetRequiredService<DbContextOptions<AppDbContext>>())) 
        {
            if (!context.Currencies.Any()) 
            {
                context.Currencies.AddRange(
                   new Entities.Currency
                   {
                       Name = "Bitcoin",
                       Description = "The first and most well-known cryptocurrency",
                       Volume24h = 45000000.00m,
                       CreatedAt = new DateTime(2009, 01, 03),
                       UpdatedAt = new DateTime(2023, 06, 14)
                   },
                    new Entities.Currency
                    {
                        Name = "Ethereum",
                        Description = "A decentralized, open-source blockchain platform",
                        Volume24h = 15000000.00m,
                        CreatedAt = new DateTime(2015, 07, 30),
                        UpdatedAt = new DateTime(2023, 06, 14)
                    }
                    );
                context.SaveChanges();
            }
            if (!context.TradingPairs.Any()) 
            {
                context.TradingPairs.AddRange(
                    new Entities.TradingPair
                    {
                        BaseAssetSymbol = "BTC",
                        QuoteAssetSymbol = "USD",
                        PriceDecimals = 2,
                        AmountDecimals = 8,
                        MinTradeSize = 0.0001m,
                        MaxTradeSize = 10m,
                        Status = TradingPairStatus.Active,
                        CreatedAt = new DateTime(2022, 01, 01),
                        UpdatedAt = new DateTime(2023, 06, 14),
                        Currency = new Entities.Currency
                        {
                            Name = "US Dollar",
                            Description = "The official currency of the United States",
                            Volume24h = 1000000000.00m,
                            CreatedAt = new DateTime(1971, 08, 15),
                            UpdatedAt = new DateTime(2023, 06, 14)
                        }
                    },
                            new Entities.TradingPair
                            {
                                BaseAssetSymbol = "ETH",
                                QuoteAssetSymbol = "BTC",
                                PriceDecimals = 8,
                                AmountDecimals = 8,
                                MinTradeSize = 0.001m,
                                MaxTradeSize = 5m,
                                Status = TradingPairStatus.Active,
                                CreatedAt = new DateTime(2022, 03, 15),
                                UpdatedAt = new DateTime(2023, 06, 14),
                                Currency = new Entities.Currency
                                {
                                    
                                    Name = "Bitcoin",
                                    Description = "The first and most well-known cryptocurrency",
                                    Volume24h = 45000000.00m,
                                    CreatedAt = new DateTime(2009, 01, 03),
                                    UpdatedAt = new DateTime(2023, 06, 14)
                                }
                            }
                    );
                context.SaveChanges();
            }
        }
    }
}
