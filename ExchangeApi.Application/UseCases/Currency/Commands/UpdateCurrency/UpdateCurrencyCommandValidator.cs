using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.Currency.Commands.UpdateCurrency;

[Validator]
public class UpdateCurrencyCommandValidator : AbstractValidator<UpdateCurrencyCommand>
{
    public UpdateCurrencyCommandValidator()
    {
        RuleFor(prop => prop.CurrencyId)
            .NotNull()
            .NotEmpty();
        
        RuleFor(prop => prop.UpdateCurrencyDto.CurrencyCode)
            .NotNull()
            .NotEmpty()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.UpdateCurrencyDto.CurrencyCode)))
            .MaximumLength(4)
            .WithMessage(item =>string.Format(Validations.MaxLength, nameof(item.UpdateCurrencyDto.CurrencyCode), 4));

        RuleFor(prop => prop.UpdateCurrencyDto.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.UpdateCurrencyDto.Name)))
            .MinimumLength(2)
            .WithMessage(item =>string.Format(Validations.MinLength, nameof(item.UpdateCurrencyDto.Name), 2));
        
        RuleFor(prop => prop.UpdateCurrencyDto.IsActive)
            .NotNull()
            .NotEmpty()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.UpdateCurrencyDto.IsActive)));
    }
}