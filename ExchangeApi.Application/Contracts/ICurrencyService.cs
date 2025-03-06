using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Application.Contracts;

public interface ICurrencyService : IGenericRepository<Currency>
{
}