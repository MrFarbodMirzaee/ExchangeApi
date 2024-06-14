using FluentValidation.AspNetCore;
using ExchangeApi.Application.Profiles;
using ExchangeApi.Shered;
using ExchangeApi.Domain.Wrappers;
using ExChangeApi.Domain.Entities;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Entitiess;
using ExchangeApi.Infrustructure.Services;

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
        Services.AddAutoMapper(typeof(Response<Currency>));
        Services.AddAutoMapper(typeof(Response<ExchangeRate>));
        Services.AddAutoMapper(typeof(Response<ExchangeTransaction>));
        Services.AddAutoMapper(typeof(Response<User>));

        return Services;
    }
}
