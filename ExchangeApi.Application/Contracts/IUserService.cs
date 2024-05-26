using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.Wrappers;
using ExChangeApi.Domain.Entities;

namespace ExchangeApi.Application.Contracts;

public interface IUserService : IGenericRepository<User>
{
  //  Task<Response<User>> GetUserById(int userId);
  //  Task<Response<User>> GetUserByEmail(string email);
  //  Task<Response<List<User>>> GetActiveUsers();
}
