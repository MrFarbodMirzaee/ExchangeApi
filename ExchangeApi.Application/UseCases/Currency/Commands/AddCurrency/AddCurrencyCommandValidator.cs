using FluentValidation;

namespace ExchangeApi.Application.UseCases.Currency.Commands;

public class AddCurrencyCommandValidator : AbstractValidator<AddCurrencyCommand>
{
    public AddCurrencyCommandValidator()
    {
        RuleFor(x => x.CurrencyCode)
            .NotEmpty()
            .NotNull()
            .MaximumLength(3)
            .WithMessage("Currency Code must not be empty and should have a maximum length of 3 characters");

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("Name must not be empty and should have a minimum length of 2 characters");
    }
}
