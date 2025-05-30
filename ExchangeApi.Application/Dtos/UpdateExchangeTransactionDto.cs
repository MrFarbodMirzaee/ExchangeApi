using FluentValidation;

namespace ExchangeApi.Application.Dtos;

public record UpdateExchangeTransactionDto(
    Guid FromCurrencyId,
    Guid ToCurrencyId,
    decimal Amount,
    decimal ResultAmount,
    Guid ExchangeRateId,
    bool IsActive,
    DateTime TransactionDate
);

public class UpdateExchangeTransactionDtoValidator : AbstractValidator<UpdateExchangeTransactionDto>
{
    public UpdateExchangeTransactionDtoValidator()
    {
        
    }
}