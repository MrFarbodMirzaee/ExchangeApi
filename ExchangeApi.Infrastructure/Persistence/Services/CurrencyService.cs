using AutoMapper;
using ExchangeApi.Application.Attributes;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Application.UseCases.Currency.Queries.GetCurrencyWithDetails;
using ExchangeApi.Application.UseCases.Currency.Queries.SearchCurrency;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.Infrastructure.Persistence.Services;

[ScopedService]
public class CurrencyService(AppDbContext applicationDbContext,IMapper mapper)
    : GenericRepository<Currency>(applicationDbContext), ICurrencyService
{
    private readonly AppDbContext _applicationDbContext = applicationDbContext;

    public async Task<Response<bool>> Activate(Guid currencyId)
    {
        var currency = await _applicationDbContext
            .Currency
            .Where(x => x.Id == currencyId)
            .FirstOrDefaultAsync();
        
        if (currency != null) 
            currency.IsActive = true;
        
        await _applicationDbContext
                .SaveChangesAsync();
        
        return new Response<bool>(true);
    }

    public async Task<Response<List<Currency>>> DynamicSearchCurrencyAsync(SearchCurrencyQuery request, CancellationToken ct)
    {
        var currencies = _applicationDbContext
            .Currency
            .AsQueryable();

        if (!string
            .IsNullOrWhiteSpace(request.Name))
        {
            currencies = currencies
                .Where(current => current.Name
                    .ToLower().Contains
                    (request.Name.ToLower()));
        }

        if (!string
                .IsNullOrWhiteSpace(request.CurrencyCode))
        {
            currencies = currencies
                .Where(current => current.CurrencyCode
                    .ToLower().Contains
                    (request.CurrencyCode.ToLower()));
        }

        if (request.IsActive != null)
        {
            currencies = currencies
                .Where(current =>
                current.IsActive == request.IsActive);
        }

        currencies = currencies
            .OrderByDescending
            (prop => prop.Id);

        return new 
            Response<List<Currency>>
            (await currencies.ToListAsync(ct));
    }

    public async Task<Response<CurrencyDetailDto>> GetCurrencyDetailsAsync(GetCurrencyWithDetailsQuery request, CancellationToken ct)
    {
        var currency = await _applicationDbContext
            .Currency
            .AsNoTracking()
            .Where(prop => prop.Id == request.Id)
            .Include(current => current.CurrencyAttributes)
            .Include(current => current.Files)
            .Include(current => current.Category)
            .FirstOrDefaultAsync(ct);
            

        var currencyDto = mapper
            .Map<CurrencyDetailDto>(currency);

        return new 
            Response<CurrencyDetailDto>
            (currencyDto);
    }
}