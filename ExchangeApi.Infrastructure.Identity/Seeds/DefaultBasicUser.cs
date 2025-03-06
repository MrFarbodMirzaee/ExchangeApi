using ExchangeApi.Application.Enums;
using ExchangeApi.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace ExchangeApi.Infrastructure.Identity.Seeds;

public static class DefaultBasicUser
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Default User
        var defaultUser = new ApplicationUser
        {
            UserName = "Farbod-Mirzaee",
            Email = "basicuser@gmail.com",
            FirstName = "John",
            LastName = "Doe",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            PhoneNumber = "09101111111",
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
            }
        }
    }
}