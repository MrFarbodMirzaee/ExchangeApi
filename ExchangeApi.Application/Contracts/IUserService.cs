using ExchangeApi.Application.Dtos;
using ExchangeApi.Application.UseCases.User.Queries.GetUserWithDetails;
using ExchangeApi.Application.UseCases.User.Queries.SearchUser;
using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Wrappers;

namespace ExchangeApi.Application.Contracts;

public interface IUserService : IGenericRepository<User>
{
    Task<Response<List<User>>> DynamicSearchUserAsync(SearchUserQuery request,CancellationToken ct);
    Task<Response<UserDetailDto>> GetUserDetailsAsync(GetUserWithDetailsQuery request,CancellationToken ct);
}