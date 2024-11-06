using ExchangeApi;
using ExchangeApi.Application;
using ExchangeApi.Infrustructure;
using ExchangeApi.MiddelWare;
using Microsoft.EntityFrameworkCore;
using Asp.Versioning;
using ExchangeApi.Infrustructure.Identity;
using Ocelot.Middleware;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using Infrastructure.Identity.Seeds;
using ExchangeApi.Infrustructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using ExchangeApi.Infrustructure.Persistence.Seeders;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ExchangeApi");
var IdentityConnectionString = builder.Configuration.GetConnectionString("ExchangeApiIdentity");

var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsetting.Develeopment.json", optional: true, reloadOnChange: true)
    .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);

var configure = configurationBuilder.Build();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services
    .RegisterApplicationServices()
    .RegisterPresentationServices(builder.Configuration, connectionString)
    .RegisterIdentityServices(builder.Configuration, IdentityConnectionString)
    .RegisterInfrustructureServices(connectionString);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "ExchangeApi", Version = "v1" });
    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please Enter The Token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    s.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{ }
        }
    });
});

var apiVersioning = builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1.0);
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("x.Version"),
        new MediaTypeApiVersionReader("ver"));
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    CurrencySeeder.Intialize(services);
    ExchangeRateSeeder.Intialize(services);
    UserSeeder.Intialize(services);
    ExchangeTransactionSeeder.Intialize(services);

    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await DefaultRoles.SeedAsync(userManager, roleManager);
    await DefaultBasicUser.SeedAsync(userManager, roleManager);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dotnetCliamAuthoriziation"));
}


app.MapHealthChecks("/health");

app.UseOcelot();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseLogUrl();

app.MapControllers();

app.Run();