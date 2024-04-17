using ExchangeApi.Application.Contracts;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExchangeApi.Infrustructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Services.AddScoped<IIpAddresssValdatorServices, IpAddreesServices>();
        return Services;
    }
}
