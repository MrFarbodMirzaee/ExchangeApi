using ExchangeApi.Application.Contracts;
using ExchangeApi.Infrustructure.Entitiesss;
using Microsoft.Extensions.DependencyInjection;


namespace ExchangeApi.Application;

public static class ConfigurationService
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection Services)
    {
        Services.AddScoped<ICurrencyService, CurrencyService>();
        Services.AddScoped<IExchangeRateService, ExchangeRateServices>();
        Services.AddScoped<IExchangeTransactionServices, ExchangeTransactionServices>();
        Services.AddScoped<IUserService, UserServices>();
        Services.AddScoped<IIpAddresssValdatorServices, IpAddreesServices>();
        return Services;
    }
}
