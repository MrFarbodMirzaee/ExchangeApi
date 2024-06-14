using ExchangeApi;
using ExchangeApi.Application;
using ExchangeApi.Infrustructure;
using ExchangeApi.MiddelWare;
using Microsoft.EntityFrameworkCore;
using Asp.Versioning;
using ExchangeApi.Infrustructure.Identity;

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
app.MapHealthChecks("/healthz");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();
//My Custome MidleWares

app.UseLogUrl();

app.MapControllers();

app.Run();