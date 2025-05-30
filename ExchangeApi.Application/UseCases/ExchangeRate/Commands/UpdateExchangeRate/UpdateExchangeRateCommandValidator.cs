using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands.UpdateExchangeRate;

[Validator]
public class UpdateExchangeRateCommandValidator : AbstractValidator<UpdateExchangeRateCommand>
{
    public UpdateExchangeRateCommandValidator()
    {
        RuleFor(prop => prop.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage(item=> string.Format(Validations.Required,nameof(item.Id)));
        
        RuleFor(prop => prop.UpdateExchangeRateDto.FromCurrency)
            .NotEmpty()
            .NotNull()
            .WithMessage(item=> string.Format(Validations.Required,nameof(item.UpdateExchangeRateDto.FromCurrency)));
        
        RuleFor(prop => prop.UpdateExchangeRateDto.ToCurrency)
            .NotEmpty()
            .NotNull()
            .WithMessage(item=> string.Format(Validations.Required,nameof(item.UpdateExchangeRateDto.ToCurrency)));

        RuleFor(prop => prop.UpdateExchangeRateDto.Rate)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.UpdateExchangeRateDto.Rate)))
            .GreaterThan(0)
            .WithMessage(item => string.Format(Validations.GreatherThan, nameof(item.UpdateExchangeRateDto.Rate), 0));


        RuleFor(prop => prop.UpdateExchangeRateDto.IsActive)
            .NotEmpty()
            .NotNull()
            .WithMessage(item=> string.Format(Validations.Required,nameof(item.UpdateExchangeRateDto.IsActive)));
    }
}