using ExchangeApi.Contexts;
using ExchangeApi.Contracts;
using ExchangeApi.Models;
using ExChangeApi.Models;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;

namespace ExchangeApi.Servcies;

public class ExchangeTransactionServices : IExchangeTransactionBusiness
{
    private readonly ApplicationDbContext _context;
    public ExchangeTransactionServices(ApplicationDbContext context) => _context = context;

    //static public List<ExchangeTransaction> exchangeTransactions = new List<ExchangeTransaction>()
    //{
    //    new ExchangeTransaction()
    //    {
    //        Id = 1,
    //        FromCurrencyId = 1,
    //        ToCurrencyId = 2 ,
    //        Amount = 100.00m,
    //        ResultAmount = 85.00m,
    //        ExChangeRateId = 1,
    //        TransactionDate = DateTime.Parse("2023-12-15 09:45:00"),
    //        Created = DateTime.Now,
    //        IsActive = true,
    //    },
    //    new ExchangeTransaction()
    //    {
    //        Id = 2,
    //        FromCurrencyId = 3,
    //        ToCurrencyId = 1 ,
    //        Amount = 100.00m,
    //        ResultAmount = 85.00m,
    //        ExChangeRateId = 1,
    //        TransactionDate = DateTime.Parse("2023-12-15 09:45:00"),
    //        Created = DateTime.Now,
    //        IsActive = true,
    //    },
    //    new ExchangeTransaction()
    //    {
    //        Id = 3,
    //        FromCurrencyId = 4,
    //        ToCurrencyId = 5,
    //        Amount = 100.00m,
    //        ResultAmount = 85.00m,
    //        ExChangeRateId = 1,
    //        TransactionDate = DateTime.Parse("2023-12-15 09:45:00"),
    //        Created = DateTime.Now,
    //        IsActive = true,
    //    },
    //};
    public bool CreateExchangeTransaction(ExchangeTransaction transaction)
    {
        _context.ExchangeTransaction.Add(transaction);
        _context.SaveChanges();
        return true;
    }

    public bool DeleteExchangeTransaction(int transactionId)
    {
        var transaction = _context.ExchangeTransaction.FirstOrDefault(x => x.Id == transactionId);
        if (transaction != null) 
        {
            _context.ExchangeTransaction.Remove(transaction);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public List<ExchangeTransaction> GetAllExchangeTransactions()
    {
        return _context.ExchangeTransaction.ToList();
    }

    public ExchangeTransaction GetExchangeTransactionById(int transactionId)
    {
        var ExcahngeTran = _context.ExchangeTransaction.Where(x => x.Id == transactionId).FirstOrDefault();
        return ExcahngeTran;
    }

    public List<ExchangeTransaction> GetTransactionsByCurrencyPair(int fromCurrencyId, int toCurrencyId)
    {
        //The GetTransactionsByCurrencyPair method filters the exchangeTransactions list to find exchange transactions for the given pair of fromCurrencyId and toCurrencyId.
        //It then returns a list of exchange transactions for the specified currency pair.

        List<ExchangeTransaction> result = _context.ExchangeTransaction
       .Where(t => t.FromCurrencyId == fromCurrencyId && t.ToCurrencyId == toCurrencyId)
       .ToList();
        return result;
    }

    public List<ExchangeTransaction> GetTransactionsByUserId(int userId)
    {
        //The GetTransactionsByUserId method filters the exchangeTransactions list to find exchange transactions for the given userId.
        //It then returns a list of exchange transactions associated with the specified user ID.

        List<ExchangeTransaction> result = _context.ExchangeTransaction
       .Where(t => t.Id == userId)
       .ToList();
        return result;
    }

    public bool UpdateExchangeTransaction(ExchangeTransaction transaction)
    {
        var ExchangeTransaction = _context.ExchangeTransaction.FirstOrDefault(x => x.Id == transaction.Id);
        if (ExchangeTransaction != null)
        {
            ExchangeTransaction.FromCurrencyId = transaction.FromCurrencyId;
            ExchangeTransaction.ToCurrencyId = transaction.ToCurrencyId;
            ExchangeTransaction.Amount = transaction.Amount;
            ExchangeTransaction.ResultAmount = transaction.ResultAmount;
            ExchangeTransaction.ExChangeRateId = transaction.ExChangeRateId;
            ExchangeTransaction.IsActive = transaction.IsActive;
            ExchangeTransaction.Updated = transaction.Updated;
            return true;
        }
        return false;
    }
}
