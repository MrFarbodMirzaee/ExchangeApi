using Exchange.gRPCServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exchange.gRPCServer.Context;

public class AppDbContext(DbContextOptions<AppDbContext> option) : DbContext(option)
{
    public DbSet<Currency> Currency { get; set; }
    public DbSet<Exchange.gRPCServer.Entities.File> File { get; set; }
}