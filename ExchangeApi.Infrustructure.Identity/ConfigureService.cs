﻿using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.UseCases.Autentication.Register;
using ExchangeApi.Application.UseCases.CurrencyAttribute;
using ExchangeApi.Domain.Settings;
using ExchangeApi.Infrustructure.Identity.Context;
using ExchangeApi.Infrustructure.Identity.Entities;
using ExchangeApi.Infrustructure.Identity.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace ExchangeApi.Infrustructure.Identity;
public static class ConfigureService
{
    public static IServiceCollection RegisterIdentityServices(this IServiceCollection services, IConfiguration configuration, string connectionstring)
    {

        services.AddDbContext<IdentityAppDbContext>(options =>
               options.UseSqlServer(
                     connectionstring,
                   b => b.MigrationsAssembly(typeof(IdentityAppDbContext).Assembly.FullName)));
        services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IdentityAppDbContext>().AddDefaultTokenProviders();
        services.AddTransient<IAutenticationService, AutenticationService>();
        services.AddScoped<AddAttributeCommandHandler>();
        services.AddScoped<RegisterCommandHandler>();

        services.Configure<JwtSettings>(configuration.GetSection("JWTSetting"));

        //Add Authentication
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    ValidAudience = configuration["JWTSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSetting:Key"]))
                };
                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";
                        return c.Response.WriteAsync(c.Exception.ToString());
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject("You are not Authorized");
                        return context.Response.WriteAsync(result);
                    },
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = 403;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject("You are not authorized to access this resource");
                        return context.Response.WriteAsync(result);
                    },
                };
            });

        return services;
    }
}
