using ExchangeApi.Application.Contracts;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExchangeApi.Infrustructure.Persistence.Services;
using ExchangeApi.Infrustructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeApi.Infrustructure;
public static class ConfigureService
{
    public static IServiceCollection RegisterInfrustructureServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));
        services.AddScoped<ICurrencyService, CurrencyService>();
        services.AddScoped<ICurrencyAttributeService, CurrencyAttributeService>();
        services.AddScoped<IExchangeRateService, ExchangeRateServices>();
        services.AddScoped<IExchangeTransactionServices, ExchangeTransactionServices>();
        services.AddScoped<IUserService, UserServices>();
        return services;
    }
}
