using ExchangeApi.Application.Contracts;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using ExchangeApi.Infrastructure.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeApi.Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));
        services.AddScoped<ICurrencyService, CurrencyService>();
        services.AddScoped<ICurrencyAttributeService, CurrencyAttributeService>();
        services.AddScoped<IExchangeRateService, ExchangeRateServices>();
        services.AddScoped<IExchangeTransactionServices, ExchangeTransactionServices>();
        services.AddScoped<IUserService, UserServices>();
        services.AddScoped<IFileService, FileService>();

        return services;
    }
}