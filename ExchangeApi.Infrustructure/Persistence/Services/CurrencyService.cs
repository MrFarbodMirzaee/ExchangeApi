using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExChangeApi.Domain.Entities;
using ExchangeApi.Infrustructure.Persistence.Services;

namespace ExchangeApi.Infrustructure.Services;
public class CurrencyService : GenericRepository<Currency>,ICurrencyService
{
    private readonly AppDbContext _applicationDbContext;
    public CurrencyService(AppDbContext applicationDbContext) : base(applicationDbContext) => _applicationDbContext = applicationDbContext;
    public async Task<Response<bool>> Activate(int currencyId)
    {
        var currency = _applicationDbContext.Currency.Where(x => x.Id == currencyId).FirstOrDefault();
        currency.IsActive = true;
        await _applicationDbContext.SaveChangesAsync();
        return new Response<bool>(true);
    }   
}
