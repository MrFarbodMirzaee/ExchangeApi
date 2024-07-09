using ExchangeApi.Application.Contracts;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExChangeApi.Domain.Entities;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Infrustructure.Persistence.Services;


namespace ExchangeApi.Infrustructure.Services;
public class UserServices : GengericRepository<User>, IUserService
{
    private readonly ApplicationDbContext _context;
    public UserServices(ApplicationDbContext context) : base(context) { _context = context; }

    public async Task<Response<bool>> Activate(int userId)
    {
        var user = _context.User.Where(x => x.Id == userId).FirstOrDefault();
        user.Activate();
        await _context.SaveChangesAsync();
        return new Response<bool>(true);
    }
}
