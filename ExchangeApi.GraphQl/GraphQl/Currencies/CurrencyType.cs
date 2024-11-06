using ExchangeApi.GraphQl.Data;
using ExchangeApi.GraphQl.Entities;

namespace ExchangeApi.GraphQl.GraphQl.Currencies;
public class CurrencyType : ObjectType<Currency>
{
    protected override void Configure(IObjectTypeDescriptor<Currency> descriptor)
    {
        descriptor.Description("Represents a cryptocurrency or digital currency.");
        descriptor.Field(u => u.Id).Description("The unique identifier of the currency.");
        descriptor.Field(u => u.Name).Description("The full name of the currency.");
        descriptor.Field(u => u.Description).Description("A brief description of the currency.");
        descriptor.Field(u => u.Volume24h).Description("The 24-hour trading volume of the currency.");
        descriptor.Field(u => u.CreatedAt).Description("The date and time when the currency was created.");
        descriptor.Field(u => u.UpdatedAt).Description("The date and time when the currency was last updated.");
    }
    private class Resolvers
    {
        private readonly AppDbContext context;

        public Resolvers(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<TradingPair> GetTradingPairs(Currency currency)
        {
            return context.TradingPairs.Where(w => w.Id == currency.Id);
        }
    }
}
