using Microsoft.AspNetCore.Identity;
using ExchangeApi.Infrustructure.Identity.Entities;
using ExchangeApi.Application.Enums;

namespace Infrastructure.Identity.Seeds;
public static class DefaultRoles
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Roles
        await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
    }
}
