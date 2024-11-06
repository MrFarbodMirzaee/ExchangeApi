using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrustructure.Persistence.Contexts;

namespace ExchangeApi.Infrustructure.Persistence.Services;
public class CurrencyAttributeService : GengericRepository<CurrencyAttribute>,ICurrencyAttributeService
{
    private readonly AppDbContext _applicationDbContext;
    public CurrencyAttributeService(AppDbContext applicationDbContext) : base(applicationDbContext) => _applicationDbContext = applicationDbContext;
}
