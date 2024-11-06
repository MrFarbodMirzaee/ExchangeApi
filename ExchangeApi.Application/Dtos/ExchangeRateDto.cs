namespace ExchangeApi.Application.Dtos;
public record ExchangeRateDto(int Id, int FromCurrency, int ToCurrency, decimal Rate);
