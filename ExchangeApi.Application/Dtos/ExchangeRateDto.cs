namespace ExchangeApi.Application.Dtos;

public record ExchangeRateDto(
    Guid Id,
    Guid FromCurrency,
    Guid ToCurrency,
    decimal Rate
);