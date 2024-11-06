using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using ExchangeApi.Infrustructure.Persistence.Services;

namespace ExchangeApi.Infrustructure.Services;
public class ExchangeTransactionServices : GengericRepository<ExchangeTransaction>, IExchangeTransactionServices
{
    private readonly AppDbContext _applicationDbContext;
    public ExchangeTransactionServices(AppDbContext applicationDbContext) : base(applicationDbContext) =>_applicationDbContext = applicationDbContext;
    
    public async Task<Response<bool>> Activate(int exchangeTransactionId)
    {
        var exchangeTransaction = _applicationDbContext.ExchangeTransaction.Where(x => x.Id == exchangeTransactionId).FirstOrDefault();
        exchangeTransaction.Activate();
        await _applicationDbContext.SaveChangesAsync();
        return new Response<bool>(true);
    }
}
