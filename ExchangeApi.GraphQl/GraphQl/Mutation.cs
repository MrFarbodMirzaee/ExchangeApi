using ExchangeApi.GraphQl.Data;
using ExchangeApi.GraphQl.Entities;
using ExchangeApi.GraphQl.GraphQl.Curremcies;
using ExchangeApi.GraphQl.GraphQl.TradingPairs;
using Microsoft.EntityFrameworkCore;


namespace ExchangeApi.GraphQl.GraphQl;

public class Mutation
{
    public async Task<AddCurrencyPayload> AddCurrencyAsync(AddCurrencyInput input, [Service] AppDbContext _context) 
    {
        var currency = new Currency
        {
            Name = input.Name
        };

        await _context.Currencies.AddAsync(currency);
        await _context.SaveChangesAsync();

        return new AddCurrencyPayload(currency);
    }
    public async Task<AddTradingPairPayload> AddTradingPairsAsync(AddTradingPairInput input, [Service] AppDbContext _context)
    {
        var tradingPair = new TradingPair
        {
          Id = input.Id,
          BaseAssetSymbol = input.BaseAssetSymbol,
          QuoteAssetSymbol = input.QuteAssetSymbol
        };

        await _context.TradingPairs.AddAsync(tradingPair);
        await _context.SaveChangesAsync();

        return new AddTradingPairPayload(tradingPair);
    }
}
