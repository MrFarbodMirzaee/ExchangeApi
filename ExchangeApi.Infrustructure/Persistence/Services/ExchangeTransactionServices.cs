using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExchangeApi.Infrustructure.Persistence.Services;


namespace ExchangeApi.Infrustructure.Services;

public class ExchangeTransactionServices : GengericRepository<ExchangeTransaction>, IExchangeTransactionServices
{
    private readonly ApplicationDbContext _context;
    public ExchangeTransactionServices(ApplicationDbContext context) : base(context) 
    {
        _context = context;
    }

    public async Task<Response<bool>> Activate(int exchangeTransactionId)
    {
        var exchangeTransaction = _context.ExchangeTransaction.Where(x => x.Id == exchangeTransactionId).FirstOrDefault();
        exchangeTransaction.Activate();
        await _context.SaveChangesAsync();
        return new Response<bool>(true);
    }
}
