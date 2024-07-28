using Microsoft.Extensions.DependencyInjection;


namespace ExchangeApi.Application;

public static class ConfigurationService
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection Services)
    {
        var assembly = typeof(ConfigurationService).Assembly;
        Services.AddMediatR(confog => confog.RegisterServicesFromAssemblies(assembly));
        return Services;
    }
}
