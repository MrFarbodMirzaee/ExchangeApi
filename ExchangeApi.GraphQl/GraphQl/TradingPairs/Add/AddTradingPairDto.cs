namespace ExchangeApi.GraphQl.GraphQl.TradingPairs.Add;

public record AddTradingPairDto(
    int Id,
    string BaseAssetSymbol,
    string QuoteAssetSymbol,
    int PriceDecimals,
    int AmountDecimals,
    decimal MinTradeSize,
    decimal MaxTradeSize
);