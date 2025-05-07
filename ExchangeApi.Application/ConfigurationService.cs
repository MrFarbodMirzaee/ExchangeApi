using Microsoft.Extensions.DependencyInjection;

namespace ExchangeApi.Application;

public static class ConfigurationService
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        var assembly = typeof(ConfigurationService).Assembly;
        
        services.AddMediatR(config =>
                    config.RegisterServicesFromAssemblies(assembly));
        
        return services;
    }
}