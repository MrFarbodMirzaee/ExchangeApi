using FluentValidation;

namespace ExchangeApi.Dtos;

public class AddCurencyDto
{
    public string CurrencyCode { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}

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
    }
}
