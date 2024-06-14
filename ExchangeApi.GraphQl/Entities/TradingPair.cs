#nullable disable
using ExchangeApi.GraphQl.Enum;

namespace ExchangeApi.GraphQl.Entities;

public class TradingPair
{
    public int Id { get; set; }
    public string BaseAssetSymbol { get; set; }
    public string QuoteAssetSymbol { get; set; }
    public int PriceDecimals { get; set; }
    public int AmountDecimals { get; set; }
    public decimal MinTradeSize { get; set; }
    public decimal MaxTradeSize { get; set; }
    public TradingPairStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Currency Currency { get; set; }
}
