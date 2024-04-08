using ExchangeApi;
using ExchangeApi.Contexts;
using ExchangeApi.MiddelWare;
using ExchangeApi.Shered;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionstring = builder.Configuration.GetConnectionString("ExchangeApi");

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionstring));

var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsetting.Develeopment.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);
var configure = configurationBuilder.Build();
// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<MySettings>(builder.Configuration.GetSection("MySettings"));
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.RegisterPresentationServices();
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
