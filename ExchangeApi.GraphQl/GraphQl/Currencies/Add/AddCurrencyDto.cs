namespace ExchangeApi.GraphQl.GraphQl.Currencies.Add;

public record AddCurrencyDto(
    string Name,
    string Description,
    decimal Volume24H
);