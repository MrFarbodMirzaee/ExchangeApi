using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrustructure.Persistence.Services;

namespace ExchangeApi.Infrustructure.Services;
public class ExchangeRateServices : GenericRepository<ExchangeRate>, IExchangeRateService
{
    private readonly AppDbContext _applicationDbContext;
    public ExchangeRateServices(AppDbContext applicationDbContext) : base(applicationDbContext) => _applicationDbContext = applicationDbContext;
}
