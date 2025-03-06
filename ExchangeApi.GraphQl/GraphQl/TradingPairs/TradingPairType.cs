using ExchangeApi.GraphQl.Data;
using ExchangeApi.GraphQl.Entities;

namespace ExchangeApi.GraphQl.GraphQl.TradingPairs;

public class TradingPairType(AppDbContext context) : ObjectType<TradingPair>
{
    private readonly AppDbContext context = context;

    protected override void Configure(IObjectTypeDescriptor<TradingPair> descriptor)
    {
    }

    private class Resolvers(AppDbContext context)
    {
        public Currency? GetAuthor(TradingPair tradingPair) =>
            context.Currencies.FirstOrDefault(u => u.Id == tradingPair.Id);
    }
}