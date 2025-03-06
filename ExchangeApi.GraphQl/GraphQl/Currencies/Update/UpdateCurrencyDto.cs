namespace ExchangeApi.GraphQl.GraphQl.Currencies.Update;

public record UpdateCurrencyDto(int Id, string Name, string Description, decimal Volume24h);