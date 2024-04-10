using ExchangeApi.Infrustructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApi.Infrustructure;

public static class ConfigureService
{
    public static IServiceCollection RegisterInfrustructureServices(this IServiceCollection Services, string connectionstring)
    {
        Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionstring));
        return Services;
    }
}
