namespace ExchangeApi.GraphQl.GraphQl.TradingPairs.Add;
public record AddTradingPairDto(int Id, string BaseAssetSymbol, string QuteAssetSymbol, int PriceDecimals, int AmountDecimals, decimal MinTradeSize, decimal MaxTradeSize);
