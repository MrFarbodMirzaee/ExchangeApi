using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.Commands.AddAttributes;

[Validator]
public class AddAttributeCommandValidator : AbstractValidator<AddAttributeCommand>
{
    public AddAttributeCommandValidator()
    {
        RuleFor(x => x.CurrencyId)
            .NotEmpty()
            .NotNull()
            .WithMessage(item=> string.Format(Validations.Required, nameof(item.CurrencyId)));

        RuleFor(x => x.Value)
            .NotEmpty()
            .NotNull()
            .WithMessage(item=> string.Format(Validations.Required, nameof(item.Value)))
            .MinimumLength(2)
            .WithMessage(item=>string.Format(Validations.MinLength, nameof(item.Value), 2));

        RuleFor(x => x.Key)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.Key)))
            .MinimumLength(2)
            .WithMessage(item =>string.Format(Validations.MinLength, nameof(item.Key), 2));
    }
}