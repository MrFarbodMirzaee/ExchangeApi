namespace ExchangeApi.Application.Dtos;

public record UpdateExchangeRateDto(
    Guid FromCurrency,
    Guid ToCurrency,
    decimal Rate,
    bool IsActive
);
