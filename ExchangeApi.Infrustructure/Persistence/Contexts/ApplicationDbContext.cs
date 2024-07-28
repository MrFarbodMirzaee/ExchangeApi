using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrustructure.Extentions;
using ExChangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace ExchangeApi.Infrustructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Currency> Currency { get; set; }
    public DbSet<ExchangeRate> ExchangeRate { get; set; }
    public DbSet<ExchangeTransaction> ExchangeTransaction { get; set; }
    public DbSet<User> User { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("BASE");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
