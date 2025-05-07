using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.Infrastructure.Persistence.Services;

public class UserServices(AppDbContext applicationDbContext)
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
}