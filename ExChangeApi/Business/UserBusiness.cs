using ExchangeApi.Contract;
using ExchangeApi.Models;
using ExChangeApi.Models;

namespace ExChangeApi.Business;

public class UserBusiness : IUserBusiness
{
    static public List<User> users = new List<User>() 
    {
        new User() { 
            Id = 1 ,
            Name = "Farbod", 
            UserName ="FarbodDeveloper501",
            EmailAddress = "Mr.FarbodMirzaee@gmail.com", 
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
       throw new NotImplementedException();
    }

    public List<User> GetAllUsers()
    {
        return users;
    }

    public User GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public User GetUserById(int userId)
    {
        var User = users.Where(x => x.Id == userId).FirstOrDefault();
        return User;
    }

    public bool UpdateUser(User user)
    {
        throw new NotImplementedException();
    }
}
