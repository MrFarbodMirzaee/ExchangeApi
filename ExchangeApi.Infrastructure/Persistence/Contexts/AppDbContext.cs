using System.Reflection;
using ExchangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ExchangeApi.Infrastructure.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    {

    }

    #region DbSets<>
    public DbSet<Category> Category { get; set; }
    public DbSet<CurrencyAttribute> CurrencyAttribute { get; set; }
    public DbSet<Currency> Currency { get; set; }
    public DbSet<ExchangeRate> ExchangeRate { get; set; }
    public DbSet<ExchangeTransaction> ExchangeTransaction { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<ExchangeApi.Domain.Entities.File> File { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("BASE");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
}