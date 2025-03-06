using FluentValidation;

namespace ExchangeApi.Application.Dtos;

public record AddExchangeTransactionDto(
    Guid FromCurrencyId,
    Guid ToCurrencyId,
    decimal Amount,
    decimal ResultAmount,
    Guid ExchangeRateId,
    bool IsActive,
    DateTime TransactionDate
);

public class AddExchangeTransactionDtoValidator : AbstractValidator<AddExchangeTransactionDto>
{
    public AddExchangeTransactionDtoValidator()
    {
        RuleFor(x => x.FromCurrencyId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please select a valid From Currency");

        RuleFor(x => x.ToCurrencyId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please select a valid To Currency");

        RuleFor(x => x.Amount)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Amount must be greater than 0");

        RuleFor(x => x.ResultAmount)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Result Amount must be greater than 0");

        RuleFor(x => x.ExchangeRateId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please select a valid Exchange Rate");

        RuleFor(x => x.TransactionDate)
            .NotEmpty()
            .NotNull()
            .WithMessage("Transaction Date cannot be in the future");

        RuleFor(x => x.IsActive)
            .NotEmpty()
            .NotNull()
            .WithMessage("Is active has to have value");
    }
}