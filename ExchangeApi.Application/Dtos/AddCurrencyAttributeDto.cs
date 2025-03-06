using FluentValidation;

namespace ExchangeApi.Application.Dtos;

public record AddCurrencyAttributeDto(
    Guid CurrencyId,
    string Key,
    string Value
);

public class AddCurrencyAttributeValidator : AbstractValidator<AddCurrencyAttributeDto>
{
    public AddCurrencyAttributeValidator()
    {
        RuleFor(x => x.Key)
            .NotEmpty()
            .NotNull()
            .MaximumLength(3)
            .WithMessage("Please Enter valid Key ");

        RuleFor(x => x.Value)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("Please Enter valid value");

        RuleFor(x => x.CurrencyId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please Enter valid Id");
    }
}