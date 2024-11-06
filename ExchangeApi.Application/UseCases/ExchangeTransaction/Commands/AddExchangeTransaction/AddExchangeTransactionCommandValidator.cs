using ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.AddExchangeTransaction;
using FluentValidation;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands;
public class AddExchangeTransactionCommandValidator : AbstractValidator<AddExchangeTransactionCommand>
{
    public AddExchangeTransactionCommandValidator()
    {
        RuleFor(x => x.FromCurrencyId)
           .NotEmpty()
           .NotNull()
           .GreaterThan(0)
           .WithMessage("Please select a valid From Currency");

        RuleFor(x => x.ToCurrencyId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
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
            .GreaterThan(0)
            .WithMessage("Please select a valid Exchange Rate");

        RuleFor(x => x.TransactionDate)
            .NotEmpty()
            .NotNull()
            .WithMessage("Transaction Date cannot be in the future");
    }
}
