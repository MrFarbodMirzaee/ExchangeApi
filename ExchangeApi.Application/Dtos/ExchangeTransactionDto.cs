namespace ExchangeApi.Application.Dtos;

public record ExchangeTransactionDto(
    Guid Id,
    Guid FromCurrencyId,
    Guid ToCurrencyId,
    decimal Amount,
    decimal ResultAmount,
    Guid ExchangeRateId,
    bool IsActive,
    DateTime TransactionDate
);