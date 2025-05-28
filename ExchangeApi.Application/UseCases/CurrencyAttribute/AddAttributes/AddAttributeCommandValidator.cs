using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.AddAttributes;

public class AddAttributeCommandValidator : AbstractValidator<AddAttributeCommand>
{
    public AddAttributeCommandValidator()
    {
        RuleFor(x => x.CurrencyId)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "CurrencyId"));

        RuleFor(x => x.Value)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "Value"))
            .MinimumLength(2)
            .WithMessage(string.Format(Validations.MinLength, "Value", 2));

        RuleFor(x => x.Key)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "Key"))
            .MinimumLength(2)
            .WithMessage(string.Format(Validations.MinLength, "Key", 2));
    }
}