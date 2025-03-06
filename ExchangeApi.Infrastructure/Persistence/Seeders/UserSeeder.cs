using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeApi.Infrastructure.Persistence.Seeders;

public class UserSeeder
{
    public static async Task Initialize(IServiceProvider service)
    {
        await using var context = new AppDbContext(service.GetRequiredService<DbContextOptions<AppDbContext>>());
        if (!context.User.Any())
        {
            context.User.AddRange(
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    UserName = "john-doe",
                    EmailAddress = "johndoe@example.com",
                    Password = "SecurePassword123",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Description = "A regular user for currency exchange.",
                    MetaDescription = "User profile for John Doe, an active currency exchange participant."
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Jane Smith",
                    UserName = "jsmith",
                    EmailAddress = "janesmith@example.com",
                    Password = "AnotherSecurePassword456",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Description = "An enthusiastic user interested in currency trading.",
                    MetaDescription = "User profile for Jane Smith, involved in currency exchange transactions."
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Alice Johnson",
                    UserName = "AliceJohnson",
                    EmailAddress = "alicejohnson@example.com",
                    Password = "Password789",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Description = "A user who frequently exchanges currencies.",
                    MetaDescription = "User profile for Alice Johnson, a regular in currency exchanges."
                });
        }

        await context.SaveChangesAsync();
    }
}