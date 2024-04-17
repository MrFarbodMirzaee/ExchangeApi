using ExchangeApi;
using ExchangeApi.Application;
using ExchangeApi.Infrustructure;
using ExchangeApi.MiddelWare;
using ExchangeApi.Shered;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionstring = builder.Configuration.GetConnectionString("ExchangeApi");

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
    .RegisterPresentationServices(builder.Configuration)
    .RegisterInfrustructureServices(connectionstring);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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