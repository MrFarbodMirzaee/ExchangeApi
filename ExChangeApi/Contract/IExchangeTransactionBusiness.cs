using ExchangeApi.Models;

namespace ExchangeApi.Contract;

public interface IExchangeTransactionBusiness
{
    List<ExchangeTransaction> GetAllExchangeTransactions();
    ExchangeTransaction GetExchangeTransactionById(int transactionId);
    bool CreateExchangeTransaction(ExchangeTransaction transaction);
    bool UpdateExchangeTransaction(ExchangeTransaction transaction);
    bool DeleteExchangeTransaction(int transactionId);
    List<ExchangeTransaction> GetTransactionsByUserId(int userId);
    List<ExchangeTransaction> GetTransactionsByCurrencyPair(int fromCurrencyId, int toCurrencyId);
}
