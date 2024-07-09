using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Contracts;



namespace ExchangeApi.Application.Contracts;

public interface IExchangeRateService : IGenericRepository<ExchangeRate>
{
}
