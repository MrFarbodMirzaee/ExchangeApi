using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetCurrencyById;

[Validator]
public class GetCurrencyByIdQueryValidator : AbstractValidator<GetCurrencyByIdQuery>
{
    public GetCurrencyByIdQueryValidator()
    {
        RuleFor(prop => prop.CurrencyId)
            .NotEmpty()
            .NotNull()
            .WithMessage(query => string.Format(Validations.Required, nameof(query.CurrencyId)));
    }
}