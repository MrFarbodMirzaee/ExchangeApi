using ExchangeApi.GraphQl.Data;
using ExchangeApi.GraphQl.GraphQl;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.GraphQl;
public static class Configuration 
{
    public static IServiceCollection RegisterGraphQlServices(this IServiceCollection services ,string con)
    {
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(con));
        services.AddGraphQLServer()
                       .AddQueryType<Query>()
                       .AddMutationType<Mutation>()
                       .AddProjections()
                       .AddFiltering()
                       .AddSorting();
        return services;
    }
}
