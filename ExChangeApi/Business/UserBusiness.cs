using ExchangeApi.Contract;
using ExchangeApi.Models;
using ExChangeApi.Models;
using System.Text.RegularExpressions;

namespace ExChangeApi.Business;

public class UserBusiness : IUserBusiness
{
    static public List<User> users = new List<User>() 
    {
        new User() { 
            Id = 1 ,
            Name = "Farbod", 
            UserName ="FarbodDeveloper501",
            EmailAddress = "mr.farbodmirzaee@gmail.com", 
            Password = "123456789",
            IsActive = true,
            Created = DateTime.Now,
            ExchangeTransactions = new List<ExchangeTransaction>
            {
             new ExchangeTransaction() 
             {
                Id = 1,
                FromCurrencyId = 1,
                ToCurrencyId = 2,
                Amount = 100.00m,
                ResultAmount = 85.00m,
                ExChangeRateId = 1,
                TransactionDate = DateTime.Parse("2023-12-15 09:45:00"),
                Created = DateTime.Now,
                IsActive = true
             },
             new ExchangeTransaction()
             {
                Id = 2,
                FromCurrencyId = 5,
                ToCurrencyId = 4,
                Amount = 70.00m,
                ResultAmount = 35.00m,
                ExChangeRateId = 1,
                TransactionDate = DateTime.Parse("2023-12-15 09:45:00"),
                Created = DateTime.Now,
                IsActive = true
             }
            }
                }
            };

    public bool CreateUser(User user)
    {
       users.Add(user); 
       return true;
    }

    public bool DeleteUser(int userId)
    {
        throw new NotImplementedException();
    }

    public List<User> GetActiveUsers()
    {
        List<User> _users = users.Where(u => u.IsActive).ToList();

        return _users;
    }
    public List<User> GetAllUsers()
    {
        return users;
    }

    public User GetUserByEmail(string email)
    {
        User user = users.FirstOrDefault(u => u.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase));

        return user;
    }

    public User GetUserById(int userId)
    {
        //The GetUserByEmail method searches for a user in the users list based on the provided email address.
        //It uses a case -insensitive comparison to match the email address.
        //The method returns the user with the specified email address or null if no user is found with that email.
        
        var User = users.Where(x => x.Id == userId).FirstOrDefault();
        return User;
    }

    public bool UpdateUser(User user)
    {
        throw new NotImplementedException();
    }    
}
