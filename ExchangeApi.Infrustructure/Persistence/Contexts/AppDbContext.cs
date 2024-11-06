using ExchangeApi.Domain.Entities;
using ExChangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExchangeApi.Infrustructure.Persistence.Contexts;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    #region DbSets<>
    public DbSet<Currency> Currency { get; set; }
    public DbSet<ExchangeRate> ExchangeRate { get; set; }
    public DbSet<ExchangeTransaction> ExchangeTransaction { get; set; }
    public DbSet<User> User { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("BASE");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
