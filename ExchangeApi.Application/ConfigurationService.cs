using ExchangeApi.Application.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime;


namespace ExchangeApi.Application;

public static class ConfigurationService
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection Services)
    {
      
        return Services;
    }
}
