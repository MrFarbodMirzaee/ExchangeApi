namespace ExchangeApi.Application.Dtos;

public record class CurrencyDto(
    Guid Id,
    string CurrencyCode,
    string Name
);