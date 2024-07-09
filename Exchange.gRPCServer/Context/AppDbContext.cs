using Exchange.gRPCServer.Models;
using Microsoft.EntityFrameworkCore;

namespace Exchange.gRPCServer.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> option) : base (option)
    {

    }

    public DbSet<Currency> Currency { get; set; }
}
