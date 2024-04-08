using FluentValidation.AspNetCore;
using ExchangeApi.Profiles;
using ExchangeApi.Servcies;
using ExchangeApi.Contracts;

namespace ExchangeApi;

public static class ConfigureService
{
    public static IServiceCollection RegisterPresentationServices(this IServiceCollection Services) 
    {
       Services.AddScoped<ICurrencyService, CurrencyService>();
       Services.AddScoped<IExchangeRateBusiness, ExchangeRateServices>();
       Services.AddScoped<IExchangeTransactionBusiness, ExchangeTransactionServices>();
       Services.AddScoped<IUserBusiness, UserServices>();
       Services.AddScoped<IIpAddresssValdatorClass, IpAddreesServices>();
       Services.AddFluentValidation();
       Services.AddAutoMapper(typeof(CurrencyProfile));
       Services.AddAutoMapper(typeof(ExchangeRateProfile));
       Services.AddAutoMapper(typeof(ExchangeTransactionProfile));
       Services.AddAutoMapper(typeof(UserProfile));
       return Services;
    }
}
