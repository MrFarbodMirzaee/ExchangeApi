using ExchangeApi.Domain.Contracts;
using ExChangeApi.Domain.Entities;

namespace ExchangeApi.Application.Contracts;

public interface IUserService : IGenericRepository<User>
{
}
