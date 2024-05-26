using ExchangeApi.Application.Contracts;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExChangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Domain.Entities;
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


    //public async Task<Response<List<User>>> GetActiveUsers()
    //{
    //    var users = await _context.User
    //        .Where(u => u.IsActive)
    //        .AsNoTracking()
    //        .ToListAsync();

    //    return new Response<List<User>>(users);
    //}

    //public async Task<Response<User>> GetUserByEmail(string email)
    //{
    //    var lowercaseEmail = email.ToLower();
    //    var user = await _context.User
    //        .AsNoTracking()
    //        .FirstOrDefaultAsync(u => u.EmailAddress.ToLower() == lowercaseEmail);
    //    return new Response<User>(user);
    //}

    //public async Task<Response<User>> GetUserById(int userId)
    //{
    //    //The GetUserByEmail method searches for a user in the users list based on the provided email address.
    //    //It uses a case -insensitive comparison to match the email address.
    //    //The method returns the user with the specified email address or null if no user is found with that email.

    //    var user = await _context.User
    //        .Where(x => x.Id == userId)
    //        .AsNoTracking()
    //        .FirstOrDefaultAsync();
    //    return new Response<User>(user);
    //}

   
}
