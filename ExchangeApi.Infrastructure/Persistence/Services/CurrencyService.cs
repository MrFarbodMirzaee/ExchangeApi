using ExchangeApi.Application.Attributes;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.Infrastructure.Persistence.Services;

[ScopedService]
public class CurrencyService(AppDbContext applicationDbContext)
    : GenericRepository<Currency>(applicationDbContext), ICurrencyService
{
    private readonly AppDbContext _applicationDbContext = applicationDbContext;

    public async Task<Response<bool>> Activate(Guid currencyId)
    {
        var currency = await _applicationDbContext
            .Currency
            .Where(x => x.Id == currencyId)
            .FirstOrDefaultAsync();
        
        if (currency != null) currency.IsActive = true;
        
        await _applicationDbContext
                .SaveChangesAsync();
        
        return new Response<bool>(true);
    }
}