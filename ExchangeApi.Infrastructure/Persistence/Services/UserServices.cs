using AutoMapper;
using ExchangeApi.Application.Attributes;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Application.UseCases.User.Queries.GetUserWithDetails;
using ExchangeApi.Application.UseCases.User.Queries.SearchUser;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.Infrastructure.Persistence.Services;

[ScopedService]
public class UserServices(AppDbContext applicationDbContext,IMapper mapper)
    : GenericRepository<User>(applicationDbContext), IUserService
{
    private readonly AppDbContext _applicationDbContext = applicationDbContext;

    public async Task<Response<bool>> Activate(Guid userId)
    {
        var user = await _applicationDbContext
            .User
            .Where(x => x.Id == userId)
            .FirstOrDefaultAsync();

        user?.Activate();

        await _applicationDbContext.SaveChangesAsync();
        return new Response<bool>(true);
    }

    public async Task<Response<List<User>>> DynamicSearchUserAsync(SearchUserQuery request, CancellationToken ct)
    {
        var users = _applicationDbContext.User.AsQueryable();

        if (!string
            .IsNullOrWhiteSpace(request.Name))
        {
            users = users
                .Where(current => current.Name
                .ToLower().Contains
                (request.Name.ToLower()));
        }

        if (!string
            .IsNullOrWhiteSpace(request.EmailAddress))
        {
            users = users
                .Where(current => current.EmailAddress
                .ToLower().Contains
                (request.EmailAddress.ToLower()));
        }

        if (!string
            .IsNullOrWhiteSpace(request.UserName))
        {
            users = users
            .Where(current => current.UserName
            .ToLower().Contains
            (request.UserName.ToLower()));
        }

        users = users
            .OrderByDescending
            (prop => prop.Id);

        return new Response<List<User>>(await users.ToListAsync(ct));
    }

    public async Task<Response<UserDetailDto>> GetUserDetailsAsync(GetUserWithDetailsQuery request, CancellationToken ct)
    {
        var user = await _applicationDbContext
            .User
            .AsNoTracking()
            .Where(prop => prop.Id == request.Id)
            .Include(current => current.ExchangeTransactions)
            .Include(current => current.Files)
            .FirstOrDefaultAsync(ct);
            

        var userDto = mapper
            .Map<UserDetailDto>(user);

        return new Response<UserDetailDto>(userDto);
    }
}