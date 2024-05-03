using FluentValidation.AspNetCore;
using ExchangeApi.Application.Profiles;
using ExchangeApi.Shered;

namespace ExchangeApi;

public static class ConfigureService
{

    public static IServiceCollection RegisterPresentationServices(this IServiceCollection Services,IConfiguration configuration,string connectionString)
    {
        Services.AddHealthChecks().AddSqlServer(connectionString);
        Services.Configure<MySettings>(configuration.GetSection("MySettings"));
        Services.AddFluentValidation();
        Services.AddHealthChecks();
        Services.AddAutoMapper(typeof(CurrencyProfile));
        Services.AddAutoMapper(typeof(ExchangeRateProfile));
        Services.AddAutoMapper(typeof(ExchangeTransactionProfile));
        Services.AddAutoMapper(typeof(UserProfile));
        return Services;
    }
}
