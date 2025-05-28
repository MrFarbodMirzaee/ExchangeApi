using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.AddExchangeTransaction;

public class AddExchangeTransactionCommandValidator : AbstractValidator<AddExchangeTransactionCommand>
{
    public AddExchangeTransactionCommandValidator()
    {
        RuleFor(x => x.FromCurrencyId)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "FromCurrencyId"))
            .GreaterThan(0)
            .WithMessage(string.Format(Validations.MaxLength, "FromCurrencyId", 0));

        RuleFor(x => x.ToCurrencyId)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "ToCurrencyId"))
            .GreaterThan(0)
            .WithMessage(string.Format(Validations.MaxLength, "ToCurrencyId", 0));

        RuleFor(x => x.Amount)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "Amount"))
            .GreaterThan(0)
            .WithMessage(string.Format(Validations.MaxLength, "Amount", 0));

        RuleFor(x => x.ResultAmount)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "ResultAmount"))
            .GreaterThan(0)
            .WithMessage(string.Format(Validations.MaxLength, "ResultAmount", 0));

        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "UserId"));

        RuleFor(x => x.ExchangeRateId)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "UserIdExchangeRateId"))
            .GreaterThan(0)
            .WithMessage(string.Format(Validations.MaxLength, "ExchangeRateId", 0));

        RuleFor(x => x.TransactionDate)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "TransactionDate"));

        RuleFor(x => x.IsActive)
           .NotEmpty()
           .NotNull()
           .WithMessage(string.Format(Validations.Required, "IsActive"));
    }
}