using ExchangeApi.Application.Attributes;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrastructure.Persistence.Contexts;

namespace ExchangeApi.Infrastructure.Persistence.Services;

[ScopedService]
public class ExchangeRateServices(AppDbContext applicationDbContext)
    : GenericRepository<ExchangeRate>(applicationDbContext), IExchangeRateService
{
}