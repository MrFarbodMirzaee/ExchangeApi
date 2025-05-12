using ExchangeApi.Application.Attributes;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.Infrastructure.Persistence.Services;

[ScopedService]
public class ExchangeTransactionServices(AppDbContext applicationDbContext)
    : GenericRepository<ExchangeTransaction>(applicationDbContext), IExchangeTransactionServices
{
    private readonly AppDbContext _applicationDbContext = applicationDbContext;

    public async Task<Response<bool>> Activate(Guid exchangeTransactionId)
    {
        var exchangeTransaction = await _applicationDbContext
            .ExchangeTransaction
            .Where(x => x.Id == exchangeTransactionId)
            .FirstOrDefaultAsync();
        
        exchangeTransaction?.Activate();
        
        await _applicationDbContext
                .SaveChangesAsync();
        return new Response<bool>(true);
    }
}