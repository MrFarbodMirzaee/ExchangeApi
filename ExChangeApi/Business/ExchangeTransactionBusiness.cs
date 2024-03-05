using ExchangeApi.Contract;
using ExchangeApi.Models;

namespace ExChangeApi.Business;

public class ExchangeTransactionBusiness : IExchangeTransactionBusiness
{
    static public List<ExchangeTransaction> exchangeTransactions = new List<ExchangeTransaction>() 
    {
        new ExchangeTransaction() 
        {
            Id = 1,
            FromCurrencyId = 1,
            ToCurrencyId = 2 ,
            Amount = 100.00m,
            ResultAmount = 85.00m,
            ExChangeRateId = 1,
            TransactionDate = DateTime.Parse("2023-12-15 09:45:00"),
            Created = DateTime.Now,
            IsActive = true,
        },
        new ExchangeTransaction()
        {
            Id = 2,
            FromCurrencyId = 3,
            ToCurrencyId = 1 ,
            Amount = 100.00m,
            ResultAmount = 85.00m,
            ExChangeRateId = 1,
            TransactionDate = DateTime.Parse("2023-12-15 09:45:00"),
            Created = DateTime.Now,
            IsActive = true,
        },
        new ExchangeTransaction()
        {
            Id = 3,
            FromCurrencyId = 4,
            ToCurrencyId = 5,
            Amount = 100.00m,
            ResultAmount = 85.00m,
            ExChangeRateId = 1,
            TransactionDate = DateTime.Parse("2023-12-15 09:45:00"),
            Created = DateTime.Now,
            IsActive = true,
        },
    };
    public bool CreateExchangeTransaction(ExchangeTransaction transaction)
    {
        exchangeTransactions.Add(transaction);
        return true;
    }

    public bool DeleteExchangeTransaction(int transactionId)
    {
        throw new NotImplementedException();
    }

    public List<ExchangeTransaction> GetAllExchangeTransactions()
    {
        return exchangeTransactions;
    }

    public ExchangeTransaction GetExchangeTransactionById(int transactionId)
    {
        var ExcahngeTran = exchangeTransactions.Where(x => x.Id == transactionId).FirstOrDefault();
        return ExcahngeTran;
    }

    public List<ExchangeTransaction> GetTransactionsByCurrencyPair(int fromCurrencyId, int toCurrencyId)
    {
        throw new NotImplementedException();
    }

    public List<ExchangeTransaction> GetTransactionsByUserId(int userId)
    {
        throw new NotImplementedException();
    }

    public bool UpdateExchangeTransaction(ExchangeTransaction transaction)
    {
        throw new NotImplementedException();
    }
}
