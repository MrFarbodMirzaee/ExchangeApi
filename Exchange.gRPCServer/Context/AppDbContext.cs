using Exchange.gRPCServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exchange.gRPCServer.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> option) : base (option)
    {

    }
    public DbSet<Currency> Currency { get; set; }
    public DbSet<Exchange.gRPCServer.Entities.File> File { get; set; }

}
