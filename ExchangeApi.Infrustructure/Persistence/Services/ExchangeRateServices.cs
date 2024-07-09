using ExchangeApi.Infrustructure.Persistence.Contexts;

using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrustructure.Persistence.Services;

namespace ExchangeApi.Infrustructure.Services;

public class ExchangeRateServices : GengericRepository<ExchangeRate>, IExchangeRateService
{
    private readonly ApplicationDbContext _context;
    public ExchangeRateServices(ApplicationDbContext context) : base(context) 
    {
        _context = context;
    }
}
