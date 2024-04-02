using ExChangeApi.Business;
using ExchangeApi.Contract;
using FluentValidation.AspNetCore;
using ExchangeApi.Profiles;
using ExchangeApi.Business;

namespace ExchangeApi;

public static class ConfigureService
{
    public static IServiceCollection RegisterPresentationServices(this IServiceCollection Services) 
    {
       Services.AddScoped<ICurrencyBusiness, CurrencyBusiness>();
       Services.AddScoped<IExchangeRateBusiness, ExchangeRateBusiness>();
       Services.AddScoped<IExchangeTransactionBusiness, ExchangeTransactionBusiness>();
       Services.AddScoped<IUserBusiness, UserBusiness>();
       Services.AddScoped<IIpAddresssValdatorClass, IpAddreesBusiness>();
       Services.AddFluentValidation();
       Services.AddAutoMapper(typeof(CurrencyProfile));
       Services.AddAutoMapper(typeof(ExchangeRateProfile));
       Services.AddAutoMapper(typeof(ExchangeTransactionProfile));
       Services.AddAutoMapper(typeof(UserProfile));
       return Services;
    }
}
