using ExchangeApi.Application.Attributes;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrastructure.Persistence.Contexts;

namespace ExchangeApi.Infrastructure.Persistence.Services;

[ScopedService]
public class CurrencyAttributeService(AppDbContext applicationDbContext)
    : GenericRepository<CurrencyAttribute>(applicationDbContext), ICurrencyAttributeService
{
}