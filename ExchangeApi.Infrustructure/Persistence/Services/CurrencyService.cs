using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExChangeApi.Domain.Entities;
using ExchangeApi.Infrustructure.Persistence.Services;


namespace ExchangeApi.Infrustructure.Services;

public class CurrencyService : GengericRepository<Currency>,ICurrencyService
{
    private readonly ApplicationDbContext _context;
    public CurrencyService(ApplicationDbContext context) : base(context) 
    {
        _context = context;
    }

    public async Task<Response<bool>> Activate(int currencyId)
    {
        var currency =  _context.Currency.Where(x => x.Id == currencyId).FirstOrDefault();
        currency.IsActive = true;
        await _context.SaveChangesAsync();
        return new Response<bool>(true);
    }   
}
