﻿using FluentValidation.AspNetCore;
using ExchangeApi.Application.Profiles;
using ExchangeApi.Shered;
namespace ExchangeApi;

public static class ConfigureService
{

    public static IServiceCollection RegisterPresentationServices(this IServiceCollection Services,IConfiguration configuration)
    {
        Services.Configure<MySettings>(configuration.GetSection("MySettings"));
        Services.AddFluentValidation();
        Services.AddAutoMapper(typeof(CurrencyProfile));
        Services.AddAutoMapper(typeof(ExchangeRateProfile));
        Services.AddAutoMapper(typeof(ExchangeTransactionProfile));
        Services.AddAutoMapper(typeof(UserProfile));
        return Services;
    }
}
