using AutoMapper;
using ExchangeApi.Application.Attributes;
using FluentValidation.AspNetCore;
using ExchangeApi.Shared;
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

        services.Scan(scan => scan
            .FromAssemblies(AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.FullName)))
            .AddClasses(classes => classes.AssignableTo<Profile>()
                .Where(type => type.GetCustomAttributes(typeof(ProfileAttribute), false).Any()))
            .As<Profile>()
            .WithSingletonLifetime());
        
        services.AddSingleton<IMapper>(provider =>
        {
            var profiles = provider.GetServices<Profile>();
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                    cfg.AddProfile(profile);
            });
            return config.CreateMapper();
        });

        return services;
    }
}