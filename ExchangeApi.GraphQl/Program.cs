using ExchangeApi.GraphQl.Data;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.GraphQl;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        string con = builder.Configuration.GetConnectionString("ExchangeApiGraphQl");
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.RegisterGraphQlServices(con);

        var app = builder.Build();

        using (var scope = app.Services.CreateScope()) 
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<AppDbContext>();
            SeedData.Intialize(services);
        }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
             app.UseGraphQLVoyager("/graphql-voyager");
        }

        app.MapGraphQL();
        
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
