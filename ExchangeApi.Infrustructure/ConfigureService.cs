using ExchangeApi.Application.Contracts;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExchangeApi.Infrustructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace ExchangeApi.Infrustructure;

public static class ConfigureService
{
    public static IServiceCollection RegisterInfrustructureServices(this IServiceCollection Services, string connectionstring)
    {
        Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionstring));
        Services.AddScoped<ICurrencyService, CurrencyService>();
        Services.AddScoped<IExchangeRateService, ExchangeRateServices>();
        Services.AddScoped<IExchangeTransactionServices, ExchangeTransactionServices>();
        Services.AddScoped<IUserService, UserServices>();
        return Services;
    }
}
