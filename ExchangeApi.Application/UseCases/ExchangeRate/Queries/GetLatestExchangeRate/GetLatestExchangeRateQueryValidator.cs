using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetLatestExchangeRate;

[Validator]
public class GetLatestExchangeRateQueryValidator : AbstractValidator<GetLatestExchangeRateQuery>
{
    public GetLatestExchangeRateQueryValidator()
    {
        RuleFor(prop => prop.FromCurrency)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.FromCurrency)));
        
        RuleFor(prop => prop.ToCurrency)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.ToCurrency)));
    }
}