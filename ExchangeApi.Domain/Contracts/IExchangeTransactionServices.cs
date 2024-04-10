using ExchangeApi.Domain.Entitiess;

namespace ExchangeApi.Application.Contracts;

public interface IExchangeTransactionServices
{
    Task<List<ExchangeTransaction>> GetAllExchangeTransactions();
    Task<ExchangeTransaction> GetExchangeTransactionById(int transactionId);
    Task<bool> CreateExchangeTransaction(ExchangeTransaction transaction);
    Task<bool> UpdateExchangeTransaction(ExchangeTransaction transaction);
    Task<bool> DeleteExchangeTransaction(int transactionId);
    Task<List<ExchangeTransaction>> GetTransactionsByUserId(int userId);
    Task<List<ExchangeTransaction>> GetTransactionsByCurrencyPair(int fromCurrencyId, int toCurrencyId);
}
