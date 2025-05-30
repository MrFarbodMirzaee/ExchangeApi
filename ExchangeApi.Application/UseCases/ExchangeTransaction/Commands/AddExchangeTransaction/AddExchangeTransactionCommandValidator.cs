using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.AddExchangeTransaction;

[Validator]
public class AddExchangeTransactionCommandValidator : AbstractValidator<AddExchangeTransactionCommand>
{
    public AddExchangeTransactionCommandValidator()
    {
        RuleFor(x => x.FromCurrencyId)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.FromCurrencyId)))
            .GreaterThan(0)
            .WithMessage(item =>string.Format(Validations.GreatherThan, nameof(item.FromCurrencyId), 0));

        RuleFor(x => x.ToCurrencyId)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.ToCurrencyId)))
            .GreaterThan(0)
            .WithMessage(item =>string.Format(Validations.GreatherThan, nameof(item.ToCurrencyId), 0));

        RuleFor(x => x.Amount)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.Amount)))
            .GreaterThan(0)
            .WithMessage(item =>string.Format(Validations.GreatherThan, nameof(item.Amount), 0));

        RuleFor(x => x.ResultAmount)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.ResultAmount)))
            .GreaterThan(0)
            .WithMessage(item =>string.Format(Validations.GreatherThan, nameof(item.ResultAmount), 0));

        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.UserId)));

        RuleFor(x => x.ExchangeRateId)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.ExchangeRateId)))
            .GreaterThan(0)
            .WithMessage(item =>string.Format(Validations.GreatherThan, nameof(item.ExchangeRateId), 0));

        RuleFor(x => x.TransactionDate)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.TransactionDate)));

        RuleFor(x => x.IsActive)
           .NotEmpty()
           .NotNull()
           .WithMessage(item =>string.Format(Validations.Required, nameof(item.IsActive)));
    }
}