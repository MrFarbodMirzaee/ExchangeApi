using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Entitiess;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace ExchangeApi.Infrustructure.Repository;

public class ExchangeTransactionServices : IExchangeTransactionServices
{
    private readonly ApplicationDbContext _context;
    public ExchangeTransactionServices(ApplicationDbContext context) => _context = context;
    public async Task<bool> CreateExchangeTransaction(ExchangeTransaction transaction)
    {
        _context.ExchangeTransaction.Add(transaction);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteExchangeTransaction(int transactionId)
    {
        var transaction = _context.ExchangeTransaction.FirstOrDefault(x => x.Id == transactionId);
        if (transaction != null) 
        {
            _context.ExchangeTransaction
            .Remove(transaction);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<List<ExchangeTransaction>> GetAllExchangeTransactions()
    {
        return await _context.ExchangeTransaction.AsNoTracking().ToListAsync();
    }

    public async Task<ExchangeTransaction> GetExchangeTransactionById(int transactionId)
    {
        var ExcahngeTran = await _context.ExchangeTransaction
            .Where(x => x.Id == transactionId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        return ExcahngeTran;
    }

    public async Task<List<ExchangeTransaction>> GetTransactionsByCurrencyPair(int fromCurrencyId, int toCurrencyId)
    {
        //The GetTransactionsByCurrencyPair method filters the exchangeTransactions list to find exchange transactions for the given pair of fromCurrencyId and toCurrencyId.
        //It then returns a list of exchange transactions for the specified currency pair.

        List<ExchangeTransaction> result = await _context.ExchangeTransaction
       .Where(t => t.FromCurrencyId == fromCurrencyId && t.ToCurrencyId == toCurrencyId)
       .AsNoTracking()
       .ToListAsync();
        return result;
    }

    public async Task<List<ExchangeTransaction>> GetTransactionsByUserId(int userId)
    {
        //The GetTransactionsByUserId method filters the exchangeTransactions list to find exchange transactions for the given userId.
        //It then returns a list of exchange transactions associated with the specified user ID.

        List<ExchangeTransaction> result = await _context.ExchangeTransaction
       .Where(t => t.Id == userId)
       .AsNoTracking()
       .ToListAsync();
        return result;
    }

    public async Task<bool> UpdateExchangeTransaction(ExchangeTransaction transaction)
    {
        var ExchangeTransaction = await _context.ExchangeTransaction.FirstOrDefaultAsync(x => x.Id == transaction.Id);
        if (ExchangeTransaction != null)
        {
            ExchangeTransaction.FromCurrencyId = transaction.FromCurrencyId;
            ExchangeTransaction.ToCurrencyId = transaction.ToCurrencyId;
            ExchangeTransaction.Amount = transaction.Amount;
            ExchangeTransaction.ResultAmount = transaction.ResultAmount;
            ExchangeTransaction.ExChangeRateId = transaction.ExChangeRateId;
            ExchangeTransaction.IsActive = transaction.IsActive;
            ExchangeTransaction.Updated = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
