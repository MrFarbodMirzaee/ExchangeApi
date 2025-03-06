using FluentValidation;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.AddAttributes;

public class AddAttributeCommandValidator : AbstractValidator<AddAttributeCommand>
{
    public AddAttributeCommandValidator()
    {
        RuleFor(x => x.CurrencyId)
            .NotEmpty()
            .NotNull()
            .WithMessage("CurrencyId must not be empty");

        RuleFor(x => x.Value)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("Value not be empty and should have a minimum length of 2 characters");

        RuleFor(x => x.Key)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("Key must not be empty and should not less than 3 characters");
    }
}