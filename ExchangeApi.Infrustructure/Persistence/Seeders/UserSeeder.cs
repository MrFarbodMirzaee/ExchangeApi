using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExChangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeApi.Infrustructure.Persistence.Seeders;

public class UserSeeder 
{
    public static void Intialize(IServiceProvider service)
    {
        using (var context = new ApplicationDbContext(service.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            if (!context.User.Any())
            {
                context.User.AddRange(
                new User
                {
                    Name = "John Doe",
                    UserName = "johndoe",
                    EmailAddress = "johndoe@example.com",
                    Password = "SecurePassword123",
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Description = "A regular user for currency exchange.",
                    MetaDescription = "User profile for John Doe, an active currency exchange participant."
                },
             new User
             {
                 Name = "Jane Smith",
                 UserName = "janesmith",
                 EmailAddress = "janesmith@example.com",
                 Password = "AnotherSecurePassword456",
                 Created = DateTime.Now,
                 Updated = DateTime.Now,
                 Description = "An enthusiastic user interested in currency trading.",
                 MetaDescription = "User profile for Jane Smith, involved in currency exchange transactions."
             },
             new User
             {
                 Name = "Alice Johnson",
                 UserName = "alicejohnson",
                 EmailAddress = "alicejohnson@example.com",
                 Password = "Password789",
                 Created = DateTime.Now,
                 Updated = DateTime.Now,
                 Description = "A user who frequently exchanges currencies.",
                 MetaDescription = "User profile for Alice Johnson, a regular in currency exchanges."
             });
            };
                context.SaveChanges();
            }
        }
    }

    
