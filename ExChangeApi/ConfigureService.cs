using FluentValidation.AspNetCore;
using ExchangeApi.Application.Profiles;
using ExchangeApi.Shered;
using ExchangeApi.Domain.Wrappers;
using ExChangeApi.Domain.Entities;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi;
public static class ConfigureService
{
    public static IServiceCollection RegisterPresentationServices(this IServiceCollection services, IConfiguration configuration, string connectionString)
    {
        services.AddHealthChecks().AddSqlServer(connectionString);
        services.Configure<MySettings>(configuration.GetSection("MySettings"));
        services.AddFluentValidation();
        services.AddHealthChecks();

        services.AddAutoMapper(typeof(CurrencyProfile));
        services.AddAutoMapper(typeof(ExchangeRateProfile));
        services.AddAutoMapper(typeof(ExchangeTransactionProfile));
        services.AddAutoMapper(typeof(UserProfile));
        services.AddAutoMapper(typeof(Response<Currency>));
        services.AddAutoMapper(typeof(Response<ExchangeRate>));
        services.AddAutoMapper(typeof(Response<ExchangeTransaction>));
        services.AddAutoMapper(typeof(Response<User>));

        return services;
    }
}
