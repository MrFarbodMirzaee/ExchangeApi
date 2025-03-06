using FluentValidation;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands.AddExchangeRate;

public class AddExchangeRateCommandValidator : AbstractValidator<AddExchangeRateCommand>
{
    public AddExchangeRateCommandValidator()
    {
        RuleFor(x => x.FromCurrency)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please select a valid From Currency");

        RuleFor(x => x.ToCurrency)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please select a valid To Currency");

        RuleFor(x => x.Rate)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Rate must be greater than 0");
    }
}