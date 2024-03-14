using ExchangeApi.Models;


namespace ExchangeApi.Contract;

public interface IUserBusiness
{
    User GetUserById(int userId);
    bool CreateUser(User user);
    bool UpdateUser(User user);
    bool DeleteUser(int userId);
    User GetUserByEmail(string email);
    List<User> GetAllUsers();
    List<User> GetActiveUsers();
}
