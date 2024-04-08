using ExchangeApi.Models;
using ExChangeApi.Models;
using Microsoft.EntityFrameworkCore;
namespace ExchangeApi.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options ) : base (options) 
    {
        
    }
    public DbSet<Currency> Currency { get; set; }
    public DbSet<ExchangeRate> ExchangeRate { get; set; }
    public DbSet<ExchangeTransaction> ExchangeTransaction { get; set; }
    public DbSet<User> User { get; set; }

}
