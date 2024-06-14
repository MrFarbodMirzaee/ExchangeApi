using ExchangeApi.GraphQl.Data;
using ExchangeApi.GraphQl.GraphQl;
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
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ExchangeApiGraphQl")));

        builder.Services.AddGraphQLServer()
                        .AddQueryType<Query>()
                        .AddMutationType<Mutation>()
                        .AddProjections()
                        .AddFiltering()
                        .AddSorting();

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
                app.UseSwagger();
                app.UseSwaggerUI();
            }

        app.MapGraphQL();
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.UseGraphQLVoyager("/graphql-voyager");

        app.Run();
    }
}
