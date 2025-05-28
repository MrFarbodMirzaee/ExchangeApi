using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands.AddExchangeRate;

public class AddExchangeRateCommandValidator : AbstractValidator<AddExchangeRateCommand>
{
    public AddExchangeRateCommandValidator()
    {
        RuleFor(x => x.FromCurrency)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "FromCurrency"));

        RuleFor(x => x.ToCurrency)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "ToCurrency"));

        RuleFor(x => x.Rate)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "Rate"))
            .GreaterThan(0)
            .WithMessage(string.Format(Validations.MaxLength, "Rate", 0));

        RuleFor(x => x.IsActive)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "IsActive"));
          
    }
}