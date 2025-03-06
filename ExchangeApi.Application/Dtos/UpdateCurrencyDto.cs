using FluentValidation;

namespace ExchangeApi.Application.Dtos;

public record UpdateCurrencyDto(
    string CurrencyCode,
    string Name,
    bool IsActive
);

public class UpdateCurrencyDtoValidator : AbstractValidator<UpdateCurrencyDto>
{
    public UpdateCurrencyDtoValidator()
    {
        RuleFor(x => x.CurrencyCode)
            .NotEmpty()
            .NotNull()
            .WithMessage("Currency Code must not be empty");
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(3)
            .WithMessage("Name must not be empty and should have a maximum length of 3 characters");

        RuleFor(x => x.IsActive)
            .NotEmpty()
            .NotNull()
            .WithMessage("Is active has to have value");
    }
}