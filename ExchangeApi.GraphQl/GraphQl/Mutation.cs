using ExchangeApi.GraphQl.Data;
using ExchangeApi.GraphQl.Entities;
using ExchangeApi.GraphQl.GraphQl.Currencies.Add;
using ExchangeApi.GraphQl.GraphQl.Currencies.Delete;
using ExchangeApi.GraphQl.GraphQl.Currencies.Update;
using ExchangeApi.GraphQl.GraphQl.TradingPairs.Add;
using ExchangeApi.GraphQl.GraphQl.TradingPairs.Delete;
using ExchangeApi.GraphQl.GraphQl.TradingPairs.Update;
using Microsoft.EntityFrameworkCore;


namespace ExchangeApi.GraphQl.GraphQl;

public class Mutation
{
    #region Currency

    public async Task<AddCurrencyPayload> AddCurrencyAsync(AddCurrencyDto dto, [Service] AppDbContext _context)
    {
        var currency = new Currency
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Description = dto.Description,
            Volume24h = dto.Volume24H,
            Name = dto.Name
        };

        _context.Currencies.Add(currency);
        await _context.SaveChangesAsync();

        return new AddCurrencyPayload(currency);
    }

    public async Task<UpdateCurrencyPayload> UpdateCurrencyAsync(UpdateCurrencyDto dto, [Service] AppDbContext _context)
    {
        var data = await _context.Currencies.FirstOrDefaultAsync(d => d.Id == dto.Id);
        if (data is null)
        {
            return null;
        }

        data.Name = dto.Name;
        data.Description = dto.Description;
        data.Volume24h = dto.Volume24H;
        _context.Currencies.Update(data);
        await _context.SaveChangesAsync();

        return new UpdateCurrencyPayload(data);
    }

    public async Task<DeleteCurrencyPayload> DeleteCurrencyAsync(DeleteCurrencyDto dto, [Service] AppDbContext _context)
    {
        var data = await _context.Currencies.FirstOrDefaultAsync(d => d.Id == dto.Id);
        if (data is null)
        {
            return null;
        }

        _context.Currencies.Remove(data);
        await _context.SaveChangesAsync();

        return new DeleteCurrencyPayload("Deleted");
    }

    #endregion

    #region TradingPairs

    public async Task<AddTradingPairPayload> AddTradingPairsAsync(AddTradingPairDto input,
        [Service] AppDbContext _context)
    {
        var tradingPair = new TradingPair
        {
            Id = input.Id,
            BaseAssetSymbol = input.BaseAssetSymbol,
            QuoteAssetSymbol = input.QuoteAssetSymbol
        };

        _context.TradingPairs.Add(tradingPair);
        await _context.SaveChangesAsync();

        return new AddTradingPairPayload(tradingPair);
    }

    public async Task<UpdateTradingPairPayload> UpdateTradingPairAsync(UpdateTradingPairDto dto,
        [Service] AppDbContext _context)
    {
        var data = await _context.TradingPairs.FirstOrDefaultAsync(d => d.Id == dto.Id);
        if (data is null)
        {
            return null;
        }

        data.BaseAssetSymbol = dto.BaseAssetSymbol;
        data.QuoteAssetSymbol = dto.QuoteAssetSymbol;
        data.AmountDecimals = dto.AmountDecimals;
        data.PriceDecimals = dto.PriceDecimals;
        data.MinTradeSize = dto.MinTradeSize;
        data.MaxTradeSize = dto.MaxTradeSize;
        _context.TradingPairs.Update(data);
        await _context.SaveChangesAsync();

        return new UpdateTradingPairPayload(data);
    }

    public async Task<DeleteTradingPairPayload> DeleteTradingPairAsync(DeleteTradingPairDto dto,
        [Service] AppDbContext _context)
    {
        var data = await _context.TradingPairs.FirstOrDefaultAsync(d => d.Id == dto.Id);
        if (data is null)
        {
            return null;
        }

        _context.TradingPairs.Remove(data);
        await _context.SaveChangesAsync();

        return new DeleteTradingPairPayload("Deleted");
    }

    #endregion
}