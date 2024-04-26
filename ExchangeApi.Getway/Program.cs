
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ExchangeApi.Getway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Configuration.AddJsonFile("Oselot.json", optional: false, reloadOnChange: true);
            builder.Services.AddOcelot(builder.Configuration);
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            
            app.UseOcelot();


            app.Run();
        }
    }
}
