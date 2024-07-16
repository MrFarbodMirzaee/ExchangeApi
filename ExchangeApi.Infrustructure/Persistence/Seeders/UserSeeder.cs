using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.Entities;
using ExChangeApi.Domain.Entities;

namespace ExchangeApi.Infrustructure.Persistence.Seeders;

public class UserSeeder : IBaseSeeder<User>
{
    public IEnumerable<User> GetSeedData()
    {
        var users = new List<User>
    {
        new User
        {
            Id = 1,
            Name = "John Doe",
            UserName = "johndoe",
            EmailAddress = "johndoe@example.com",
            Password = "password123",
            Created = DateTime.Now,
            ExchangeTransactions = new List<ExchangeTransaction>(),
            Updated = DateTime.Now,
            Description = "This is the first user.",
            MetaDescription = "John Doe is the primary user.",
            DeletedByUserId = 0,
            UpdatedByUserId = 1
        },
        new User
        {
            Id = 2,
            Name = "Jane Smith",
            UserName = "janesmith",
            EmailAddress = "janesmith@example.com",
            Password = "password456",
            Created = DateTime.Now,
            ExchangeTransactions = new List<ExchangeTransaction>(),
            Updated = DateTime.Now,
            Description = "This is the second user.",
            MetaDescription = "Jane Smith is the secondary user.",
            DeletedByUserId = 0,
            UpdatedByUserId = 1
        },
        new User
        {
            Id = 3,
            Name = "Bob Johnson",
            UserName = "bobjohnson",
            EmailAddress = "bobjohnson@example.com",
            Password = "password789",
            Created = DateTime.Now,
            ExchangeTransactions = new List<ExchangeTransaction>(),
            Updated = DateTime.Now,
            Description = "This is the third user.",
            MetaDescription = "Bob Johnson is the tertiary user.",
            DeletedByUserId = 0,
            UpdatedByUserId = 1
        }
    };

        foreach (var user in users)
        {
            user.Activate();
        }

        return users;
    }
}
    
