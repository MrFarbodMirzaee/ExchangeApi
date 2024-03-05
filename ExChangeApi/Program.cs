using ExchangeApi.Contract;
using ExChangeApi.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<ICurrencyBusiness, CurrencyBusiness>();
builder.Services.AddSingleton<IExchangeRateBusiness, ExchangeRateBusiness>();
builder.Services.AddSingleton<IExchangeTransactionBusiness, ExchangeTransactionBusiness>();
builder.Services.AddSingleton<IUserBusiness, UserBusiness>();
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

app.MapControllers();

app.Run();
