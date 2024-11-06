using ExchangeApi.Application.Contracts;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExChangeApi.Domain.Entities;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Infrustructure.Persistence.Services;

namespace ExchangeApi.Infrustructure.Services;
public class UserServices : GengericRepository<User>, IUserService
{
    private readonly AppDbContext _applicationDbContext;
    public UserServices(AppDbContext applicationDbContext) : base(applicationDbContext) => _applicationDbContext = applicationDbContext; 
    public async Task<Response<bool>> Activate(int userId)
    {
        var user = _applicationDbContext.User.Where(x => x.Id == userId).FirstOrDefault();
        user.Activate();
        await _applicationDbContext.SaveChangesAsync();
        return new Response<bool>(true);
    }
}
