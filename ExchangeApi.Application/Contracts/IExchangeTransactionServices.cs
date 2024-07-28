using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Contracts;
namespace ExchangeApi.Application.Contracts;

public interface IExchangeTransactionServices : IGenericRepository<ExchangeTransaction>
{
}
