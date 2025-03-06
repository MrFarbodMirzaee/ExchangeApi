using FluentValidation;

namespace ExchangeApi.Application.Dtos;

public record UpdateExchangeRateDto(
    Guid FromCurrency,
    Guid ToCurrency,
    decimal Rate,
    bool IsActive
);

public class UpdateExchangeRateDtoValidator : AbstractValidator<UpdateExchangeRateDto>
{
    public UpdateExchangeRateDtoValidator()
    {
        RuleFor(x => x.FromCurrency)
            .NotEmpty()
            .NotNull()
            .WithMessage("FromCurrency must not be empty");
        
        RuleFor(x => x.ToCurrency)
            .NotEmpty()
            .NotNull()
            .WithMessage("ToCurrency must not be empty");

        RuleFor(x => x.Rate)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Rate must not be empty and should be greeter than 0 ");

        RuleFor(x => x.IsActive)
            .NotEmpty()
            .NotNull()
            .WithMessage("Is active has to have value");
    }
}