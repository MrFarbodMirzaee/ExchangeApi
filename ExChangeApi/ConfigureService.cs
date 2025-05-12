using FluentValidation.AspNetCore;
using ExchangeApi.Application.Profiles.Currency;
using ExchangeApi.Application.Profiles.ExchangeRate;
using ExchangeApi.Application.Profiles.ExchangeTransaction;
using ExchangeApi.Application.Profiles.File;
using ExchangeApi.Application.Profiles.User;
using ExchangeApi.Shared;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Domain.Entities;
using QuestPDF.Infrastructure;

namespace ExchangeApi;

public static class ConfigureService
{
    public static IServiceCollection RegisterPresentationServices(this IServiceCollection services,
        IConfiguration configuration, string connectionString)
    {
        #region PdfLicense
        QuestPDF.Settings.License = LicenseType.Community;
        #endregion

        services.AddHealthChecks()
            .AddSqlServer(connectionString);

        services.Configure<MySettings>
            (configuration.GetSection("MySettings"));

        services.AddFluentValidation();
        services.AddHealthChecks();

        services.AddAutoMapper
            (typeof(CurrencyProfile));
        services.AddAutoMapper
            (typeof(ExchangeRateProfile));
        services.AddAutoMapper
            (typeof(ExchangeTransactionProfile));
        services.AddAutoMapper
            (typeof(UserProfile));
        services.AddAutoMapper
            (typeof(Response<Currency>));
        services.AddAutoMapper
            (typeof(Response<ExchangeRate>));
        services.AddAutoMapper
            (typeof(Response<ExchangeTransaction>));
        services.AddAutoMapper
            (typeof(Response<User>));
        services.AddAutoMapper
            (typeof(FileProfile));

        return services;
    }
}