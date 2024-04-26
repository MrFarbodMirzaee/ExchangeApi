using ExchangeApi.Infrustructure.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.Infrustructure.Identity.Context;

public class IdentityContext : IdentityDbContext<ApplicationUser>
{
    //public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    //{

    //}
}
