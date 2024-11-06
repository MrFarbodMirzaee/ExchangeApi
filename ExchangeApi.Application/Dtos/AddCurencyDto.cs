using FluentValidation;

namespace ExchangeApi.Application.Dtos;

public record AddCurencyDto(string CurrencyCode, string Name, bool IsActive);
public class AddCurrecyDtoValidator : AbstractValidator<AddCurencyDto>
{
    public AddCurrecyDtoValidator()
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

        RuleFor(x => x.IsActive)
            .NotEmpty()
            .NotNull()
            .WithMessage("Is active has to have value");
    }
}
