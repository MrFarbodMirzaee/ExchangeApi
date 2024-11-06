using ExchangeApi.GraphQl.Data;
using ExchangeApi.GraphQl.Entities;

namespace ExchangeApi.GraphQl.GraphQl.TradingPairs;
public class TradingPairType : ObjectType<TradingPair>
{
    private readonly AppDbContext context;

    public TradingPairType(AppDbContext context)
    {
        this.context = context;
    }
    protected override void Configure(IObjectTypeDescriptor<TradingPair> descriptor)
    {
      
    }
    private class Resolvers
    {
         private readonly AppDbContext _context;
         public Resolvers(AppDbContext context) => _context = context;
         public Currency? GetAuthor(TradingPair tradingPair) => _context.Currencies.FirstOrDefault(u => u.Id == tradingPair.Id );
    }
}
