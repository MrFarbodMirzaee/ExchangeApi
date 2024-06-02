using FluentValidation;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands;

public class AddExchagneRateCommandValidator : AbstractValidator<AddExchagneRateCommand>
{
    public AddExchagneRateCommandValidator()
    {
        RuleFor(x => x.FromCurrency)
          .NotEmpty()
          .NotNull()
          .GreaterThan(0)
          .WithMessage("Please select a valid From Currency");

        RuleFor(x => x.ToCurrency)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Please select a valid To Currency");

        RuleFor(x => x.Rate)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Rate must be greater than 0");
    }
}
