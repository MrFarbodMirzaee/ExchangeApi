using Exchange.gRPCServer;
using Exchange.gRPCServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("secrets.json", optional: true, reloadOnChange: true);

var con = builder.Configuration.GetConnectionString("ExchangeApiGrpc");

if (con != null) builder.Services.RegisterGrpcServices(con);

builder.Services.AddGrpcReflection();

var app = builder.Build();

app.MapGrpcReflectionService();

app.MapGrpcService<GrpcCurrencyService>();
app.MapGrpcService<GrpcCurrencyImageFileStreamingService>();
app.MapGrpcService<GrpcStreamingCurrencyService>();
app.MapGrpcService<DownloadFileService>();
app.MapGrpcService<GetAllFilesService>();

app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();