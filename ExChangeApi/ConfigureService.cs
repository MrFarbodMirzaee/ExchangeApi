using FluentValidation.AspNetCore;
using ExchangeApi.Profiles;
namespace ExchangeApi;

public static class ConfigureService
{

    public static IServiceCollection RegisterPresentationServices(this IServiceCollection Services)
    {
        Services.AddFluentValidation();
        Services.AddAutoMapper(typeof(CurrencyProfile));
        Services.AddAutoMapper(typeof(ExchangeRateProfile));
        Services.AddAutoMapper(typeof(ExchangeTransactionProfile));
        Services.AddAutoMapper(typeof(UserProfile));
        return Services;
    }
}
