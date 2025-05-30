using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetExchangeRateByCurrencyPair;

[Validator]
public class GetExchangeRateByCurrencyPairQueryValidator : AbstractValidator<GetExchangeRateByCurrencyPairQuery>
{
    public GetExchangeRateByCurrencyPairQueryValidator()
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