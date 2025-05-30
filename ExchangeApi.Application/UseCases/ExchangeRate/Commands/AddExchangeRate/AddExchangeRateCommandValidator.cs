using DocumentFormat.OpenXml.Spreadsheet;
using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands.AddExchangeRate;

[Validator]
public class AddExchangeRateCommandValidator : AbstractValidator<AddExchangeRateCommand>
{
    public AddExchangeRateCommandValidator()
    {
        RuleFor(x => x.FromCurrency)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.FromCurrency)));

        RuleFor(x => x.ToCurrency)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.ToCurrency)));

        RuleFor(x => x.Rate)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.Rate)))
            .GreaterThan(0)
            .WithMessage(item =>string.Format(Validations.GreatherThan, nameof(item.Rate), 0));

        RuleFor(x => x.IsActive)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.IsActive)));
          
    }
}