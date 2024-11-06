using Exchange.gRPCServer;
using Exchange.gRPCServer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("secrets.json", optional: true, reloadOnChange: true);

var con = builder.Configuration.GetConnectionString("ExchangeApiGrpc");
builder.Services.RegisterGrpcServices(con);


//Add Grpc Reflection for test in postman
builder.Services.AddGrpcReflection();

var app = builder.Build();
//to use into postman  
app.MapGrpcReflectionService();
// Configure the HTTP request pipeline.
app.MapGrpcService<GrpcCurrencyService>();
app.MapGrpcService<GrpcCurrencyImageFileStreamingService>();
app.MapGrpcService<GrpcStreamingCurrencyService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();