using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetAllCurrency;

[Validator]
public class GetAllCurrencyQueryValidator : AbstractValidator<GetAllCurrencyQuery>
{
    public GetAllCurrencyQueryValidator()
    {
        RuleFor(prop => prop.QueryCriteria.Skip)
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.QueryCriteria.Skip)));
        
        RuleFor(prop => prop.QueryCriteria.Take)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.QueryCriteria.Take)));
    }
}