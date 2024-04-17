using ExChangeApi.Domain.Entities;

namespace ExchangeApi.Application.Contracts;

public interface IUserService
{
    Task<User> GetUserById(int userId);
    Task<bool> CreateUser(User user);
    Task<bool> UpdateUser(User user);
    Task<bool> DeleteUser(int userId);
    Task<User> GetUserByEmail(string email);
    Task<List<User>> GetAllUsers();
    Task<List<User>> GetActiveUsers();
}
