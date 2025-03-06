using Exchange.gRPCServer.Context;
using Microsoft.EntityFrameworkCore;

namespace Exchange.gRPCServer;

public static class Configuration
{
    public static IServiceCollection RegisterGrpcServices(this IServiceCollection services, string con)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(con));
        return services;
    }
}