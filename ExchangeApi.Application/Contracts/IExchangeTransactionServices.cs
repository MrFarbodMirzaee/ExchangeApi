using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Contracts;
namespace ExchangeApi.Application.Contracts;

public interface IExchangeTransactionServices : IGenericRepository<ExchangeTransaction>
{
  //  Task<Response<List<ExchangeTransaction>>> GetExchangeTransactionById(int transactionId);
  //  Task<Response<List<ExchangeTransaction>>> GetTransactionsByUserId(int userId);
  //  Task<Response<List<ExchangeTransaction>>> GetTransactionsByCurrencyPair(int fromCurrencyId, int toCurrencyId);

}
