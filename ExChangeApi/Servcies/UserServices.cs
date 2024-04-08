using ExchangeApi.Contexts;
using ExchangeApi.Contracts;
using ExchangeApi.Models;
using ExChangeApi.Models;
using System.Text.RegularExpressions;

namespace ExchangeApi.Servcies;

public class UserServices : IUserBusiness
{
    private readonly ApplicationDbContext _context;
    public UserServices(ApplicationDbContext context) => _context = context;

    public bool CreateUser(User user)
    {
        _context.User.Add(user);
        _context.SaveChanges();
        return true;
    }

    public bool DeleteUser(int userId)
    {
        var user = _context.User.FirstOrDefault(x => x.Id == userId);
        if (user != null) 
        {
            _context.User.Remove(user);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public List<User> GetActiveUsers()
    {
        List<User> _users = _context.User.Where(u => u.IsActive).ToList();

        return _users;
    }
    public List<User> GetAllUsers()
    {
        return _context.User.ToList();
    }

    public User GetUserByEmail(string email)
    {
        User user = _context.User.FirstOrDefault(u => u.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase));

        return user;
    }

    public User GetUserById(int userId)
    {
        //The GetUserByEmail method searches for a user in the users list based on the provided email address.
        //It uses a case -insensitive comparison to match the email address.
        //The method returns the user with the specified email address or null if no user is found with that email.

        var User = _context.User.Where(x => x.Id == userId).FirstOrDefault();
        return User;
    }

    public bool UpdateUser(User user)
    {
        var updateUser = _context.User.FirstOrDefault(x => x.Id == user.Id);
        if (updateUser != null) 
        {
            updateUser.Name = user.Name;
            updateUser.UserName = user.UserName;
            updateUser.EmailAddress = user.EmailAddress;
            updateUser.Password = user.Password;
            updateUser.IsActive = user.IsActive;
            updateUser.Updated = user.Updated;
            return true;
        }
        return false;
    }
}
