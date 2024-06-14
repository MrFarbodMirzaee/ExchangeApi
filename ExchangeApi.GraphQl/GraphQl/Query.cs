using ExchangeApi.GraphQl.Data;
using ExchangeApi.GraphQl.Entities;

namespace ExchangeApi.GraphQl.GraphQl;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Currency> Currencies([Service] AppDbContext _Context) 
    => _Context.Currencies;


    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TradingPair> TraidingPairs([Service] AppDbContext _Context)
    => _Context.TradingPairs;
}
