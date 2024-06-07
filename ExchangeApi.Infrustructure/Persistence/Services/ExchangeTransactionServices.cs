using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
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


    //public async Task<Response<List<ExchangeTransaction>>> GetExchangeTransactionById(int transactionId)
    //{
    //    var exchangeTrans = await _context.ExchangeTransaction
    //        .Where(x => x.Id == transactionId)
    //        .AsNoTracking()
    //        .ToListAsync();

    //    if (exchangeTrans.Count == 0)
    //    {
    //        return new Response<List<ExchangeTransaction>>(null, "No exchange transactions found");
    //    }

    //    return new Response<List<ExchangeTransaction>>(exchangeTrans);
    //}


    //public async Task<Response<List<ExchangeTransaction>>> GetTransactionsByCurrencyPair(int fromCurrencyId, int toCurrencyId)
    //{
    //    //The GetTransactionsByCurrencyPair method filters the exchangeTransactions list to find exchange transactions for the given pair of fromCurrencyId and toCurrencyId.
    //    //It then returns a list of exchange transactions for the specified currency pair.

    //    List<ExchangeTransaction> result = await _context.ExchangeTransaction
    //   .Where(t => t.FromCurrencyId == fromCurrencyId && t.ToCurrencyId == toCurrencyId)
    //   .AsNoTracking()
    //   .ToListAsync();
    //    return new Response<List<ExchangeTransaction>>(result);
    //}

    //public async Task<Response<List<ExchangeTransaction>>> GetTransactionsByUserId(int userId)
    //{
    //    //The GetTransactionsByUserId method filters the exchangeTransactions list to find exchange transactions for the given userId.
    //    //It then returns a list of exchange transactions associated with the specified user ID.

    //    List<ExchangeTransaction> result = await _context.ExchangeTransaction
    //   .Where(t => t.Id == userId)
    //   .AsNoTracking()
    //   .ToListAsync();
    //    return new Response<List<ExchangeTransaction>>(result);
    //}


}
