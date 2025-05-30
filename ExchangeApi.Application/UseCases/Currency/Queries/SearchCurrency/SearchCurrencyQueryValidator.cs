using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.Currency.Queries.SearchCurrency;

[Validator]
public class SearchCurrencyQueryValidator : AbstractValidator<SearchCurrencyQuery>
{
    public SearchCurrencyQueryValidator()
    {
        RuleFor(x => x.CurrencyCode)
            .MaximumLength(4)
            .WithMessage(search => string.Format(Validations.MaxLength,nameof(search.CurrencyCode),4));

        RuleFor(x => x.Name)
            .MaximumLength(50)
            .WithMessage(search => string.Format(Validations.MaxLength,nameof(search.Name),50))
            .MinimumLength(2)
            .WithMessage(search => string.Format(Validations.MinLength,nameof(search.Name),2));
    }
}