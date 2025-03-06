using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ExchangeApi.Infrastructure.Identity.Context;

public class AppDbContextIdentityFactory : IDesignTimeDbContextFactory<IdentityAppDbContext>
{
    public IdentityAppDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../ExchangeApi");
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<IdentityAppDbContext>();
        var connectionString = configuration.GetConnectionString("ExchangeApi_Identity");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string not found in appsettings.json");
        }

        optionsBuilder.UseSqlServer(connectionString);

        return new IdentityAppDbContext(optionsBuilder.Options);
    }
}