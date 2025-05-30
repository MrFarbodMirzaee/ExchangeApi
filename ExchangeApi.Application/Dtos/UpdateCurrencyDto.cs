namespace ExchangeApi.Application.Dtos;

public record UpdateCurrencyDto(
    string CurrencyCode,
    string Name,
    bool IsActive
);
