﻿using ExchangeApi.Application.Contracts;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExChangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExchangeApi.Infrustructure.Entitiesss;
public class UserServices : IUserService
{
    private readonly ApplicationDbContext _context;
    public UserServices(ApplicationDbContext context) => _context = context;

    public async Task<bool> CreateUser(User user)
    {
        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUser(int userId)
    {
        var user = _context.User.FirstOrDefault(x => x.Id == userId);
        if (user != null) 
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<List<User>> GetActiveUsers()
    {
        List<User> _users = await _context.User
            .Where(u => u.IsActive)
            .ToListAsync();

        return _users;
    }
    public async Task<List<User>> GetAllUsers()
    {
        var data = await _context.User.AsNoTracking().ToListAsync();
        return data;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        User user = await _context.User
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase));
        return user;
    }

    public async Task<User> GetUserById(int userId)
    {
        //The GetUserByEmail method searches for a user in the users list based on the provided email address.
        //It uses a case -insensitive comparison to match the email address.
        //The method returns the user with the specified email address or null if no user is found with that email.

        var User = await _context.User.Where(x => x.Id == userId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        return User;
    }

    public async Task<bool> UpdateUser(User user)
    {
        var updateUser = await _context.User.FirstOrDefaultAsync(x => x.Id == user.Id);
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