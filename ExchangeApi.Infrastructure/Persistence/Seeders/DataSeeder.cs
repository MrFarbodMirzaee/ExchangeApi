using System.Security.Cryptography;
using ExchangeApi.Application.Helper;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using File = ExchangeApi.Domain.Entities.File;

namespace ExchangeApi.Infrastructure.Persistence.Seeders;

public class DataSeeder
{
    public static async Task Initialize(IServiceProvider service)
    {
        await using var context =
            new AppDbContext
            (service
                .GetRequiredService
                <DbContextOptions<AppDbContext>>());



        if (!await context.Currency.AnyAsync() &&
            !await context.User.AnyAsync() &&
            !await context.ExchangeRate.AnyAsync() &&
            !await context.File.AnyAsync() &&
            !await context.ExchangeTransaction.AnyAsync() &&
            !await context.Category.AnyAsync() &&
            !await context.CurrencyAttribute.AnyAsync())
        {
            var users = new List<User>();
            var currencies = new List<Currency>();
           
            for (int count = 0; count <= 2; count++)
            {
                byte[] salt = new byte[16];
        
                using  var numberGenerator = RandomNumberGenerator.Create();
                numberGenerator.GetBytes(salt);
                   
                var uniquePassword = $"hashed_password{count}";
                var hashedPassword = PasswordHelper.HashPasswordWithArgon2(uniquePassword, salt);
                
                var (code, name, fileName) = count switch
                {
                    0 => ("BTC", "Bitcoin", "BTC.jpeg"),
                    1 => ("ETC", "Ethereum Classic", "ETC.png"),
                    2 => ("USDT", "Tether (USDT)", "USDT.png"),
                    _ => throw new ArgumentOutOfRangeException()
                };
                    
                var (userCode, userName, userFileName) = count switch
                {
                    0 => ("User", "User", "User.jpeg"),
                    1 => ("User", "User", "User.jpeg"),
                    2 => ("User", "User", "User.jpeg"),
                    _ => throw new ArgumentOutOfRangeException()
                };
                
                var sourceFilePath = new System.Diagnostics.StackTrace(true)
                    .GetFrame(0)?
                    .GetFileName();

                if (sourceFilePath == null)
                    throw new Exception("Cannot determine source file path for DataSeeder");

                var sourceFolder = Path
                    .GetDirectoryName(sourceFilePath)!;

                var currencyImages = Path
                    .Combine(sourceFolder, "Images","Currencies");
                    
                var userFolder = Path
                    .Combine(sourceFolder, "Images","Users");

                var currencyFiles = Path
                    .Combine(currencyImages, fileName);
                    
                var userFiles = Path
                    .Combine(userFolder, userFileName);

                if (!System.IO.File.Exists(currencyFiles))
                {
                    throw new FileNotFoundException($"Image file not found at {currencyFiles}");
                }
                    
                if (!System.IO.File.Exists(userFiles))
                {
                    throw new FileNotFoundException($"Image file not found at {userFiles}");
                }

           
                
                var currencyId = Guid.NewGuid();
                var userId = Guid.NewGuid();
                var user = new User()
                {
                    Id = userId,
                    Name = $"Test User {count + 1}",
                    UserName = $"testuser{count + 1}",
                    EmailAddress = $"user{count + 1}@example.com",
                    Password = hashedPassword, 
                    Description = "Seeded user account",
                    DeletedByUserId = null,
                    UpdatedByUserId = null,
                    MetaDescription = $"This is a seeded test user account number {count + 1} created for initial data population and testing purposes.",
                    Files = new List<File>()
                    {
                        new File(){
                            Id = Guid.NewGuid(),
                            FileName = userFileName,
                            FileData = System.IO.File.ReadAllBytes(userFiles),
                            ContentType = "image/png",
                            MetaDescription = $"High‑resolution logo image for {code} ({name})",
                            DeletedByUserId = null,
                            CurrencyId = currencyId
                        }
                    }
                };
                    user.Activate();

                var currency = new Currency
                {
                    Id = currencyId,
                    CurrencyCode = count switch
                    {
                        0 => "BTC",
                        1 => "ETC",
                        2 => "USDT",
                    },
                    Name = count switch
                    {
                        0 => "Bitcoin",
                        1 => "Ethereum Classic",
                        2 => "Tether (USDT)",
                    },
                    IsActive = true,
                    ImagePath = count switch
                    {
                        0 => "/images/BTC.jpeg",
                        1 => "/images/ETC.png",
                        2 => "/images/USDT.png",
                    },
                    Description = count switch
                    {
                        0 => "Decentralized digital currency without a central bank or single administrator.",
                        1 => "An open-source blockchain computing platform featuring smart contract functionality.",
                        2 => "A stablecoin pegged to the US Dollar, widely used in crypto exchanges."
                    },
                    MetaDescription = count switch
                    {
                        0 => "Bitcoin is the first decentralized cryptocurrency enabling peer-to-peer digital payments without intermediaries.",
                        1 => "Ethereum Classic is a blockchain platform supporting smart contracts with an emphasis on immutability.",
                        2 => "Tether (USDT) is a popular stablecoin designed to maintain a 1:1 peg with the US Dollar for stability.",
                    },
                    DeletedByUserId = null,
                    UpdatedByUserId = userId,
                    CurrencyAttributes = new List<CurrencyAttribute>()
                    {
                        new CurrencyAttribute()
                        {
                            Id = Guid.NewGuid(),
                            UserId = userId,
                            Key = "Symbol",
                            Value = count switch
                            {
                                0 => "₿",
                                1 => "Ξ",
                                2 => "₮"
                            },
                            IsActive = true,
                            Description = "Currency symbol",
                            MetaDescription = "Symbol representing this currency"
                        },
                        new CurrencyAttribute()
                        {
                            Id = Guid.NewGuid(),
                            UserId = userId,
                            Key = "Region",
                            Value = count switch
                            {
                                0 => "Global",
                                1 => "Global",
                                2 => "Global"
                            },
                            IsActive = true,
                            Description = "Primary usage region",
                            MetaDescription = "Where the currency is commonly used"
                        },
                        new CurrencyAttribute()
                        {
                            Id = Guid.NewGuid(),
                            UserId = userId,
                            Key = "Type",
                            Value = count switch
                            {
                                0 => "Cryptocurrency",
                                1 => "Cryptocurrency",
                                2 => "Stablecoin"
                            },
                            IsActive = true,
                            Description = "Type of currency",
                            MetaDescription = "Defines whether it's a coin or a token"
                        }
                    },
                    Category = new Category
                    {
                        Id = Guid.NewGuid(),
                        Name = count switch
                        {
                            0 => "Cryptocurrency",
                            1 => "Cryptocurrency",
                            2 => "Stablecoin"
                        },
                        Description = count switch
                        {
                            0 => "Currencies built on blockchain with no central authority",
                            1 => "Smart-contract compatible blockchain currencies",
                            2 => "Digitally-issued tokens pegged to fiat currency"
                        },
                        MetaDescription = count switch
                        {
                            0 => "Decentralized digital currencies like Bitcoin with secure, peer-to-peer transactions",
                            1 => "Blockchain currencies that support programmable smart contracts like Ethereum Classic",
                            2 => "Stable digital tokens like USDT that maintain value by pegging to fiat currency",
                        },
                        UpdatedByUserId = userId,
                        DeletedByUserId = null
                    },
                    Files = new List<File>()
                    {
                        new File(){
                            Id = Guid.NewGuid(),
                            FileName = fileName,
                            FileData = System.IO.File.ReadAllBytes(currencyFiles),
                            ContentType = "image/png",
                            MetaDescription = $"High‑resolution logo image for {code} ({name})",
                            DeletedByUserId = null,
                        }
                    }
                };
                currencies
                    .Add(currency);
                
                users
                    .Add(user);
            }
            await context
                .AddRangeAsync(users);
            
            await context
                .AddRangeAsync(currencies);
        }

        await context
            .SaveChangesAsync();
    }
}