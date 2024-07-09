namespace ExchangeApi.GraphQl.GraphQl.TradingPairs.Update;

public record UpdateTradingPairDto(int Id, string BaseAssetSymbol, string QuoteAssetSymbol, int PriceDecimals, int AmountDecimals,decimal MinTradeSize, decimal MaxTradeSize);


