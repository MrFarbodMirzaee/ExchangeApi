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

var builder = WebApplication.CreateBuilder(args);

var connectionstring = builder.Configuration.GetConnectionString("ExchangeApi");
var Identityconnectionstring = builder.Configuration.GetConnectionString("ExchangeApiIdentity");

var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsetting.Develeopment.json", optional: true, reloadOnChange: true)
    .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);
var configure = configurationBuilder.Build();
// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services
    .RegisterApplicationServices()
    .RegisterPresentationServices(builder.Configuration, connectionstring)
    .RegisterIdentityServices(builder.Configuration, Identityconnectionstring)
    .RegisterInfrustructureServices(connectionstring);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

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
    var context = services.GetRequiredService<ApplicationDbContext>();
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
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health");

app.UseOcelot();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseLogUrl();

app.MapControllers();

app.Run();