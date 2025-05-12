using ExchangeApi.Application.Attributes;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeApi.Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<AppDbContext>(option 
            => option.UseSqlServer(connectionString));
        
        services.Scan(s => s
            .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            .AddClasses(classes => classes.WithAttribute<ScopedServiceAttribute>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        
        return services;
    }
}