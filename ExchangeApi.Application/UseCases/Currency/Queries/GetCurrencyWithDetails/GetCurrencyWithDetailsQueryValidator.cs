using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetCurrencyWithDetails;

[Validator]
public class GetCurrencyWithDetailsQueryValidator : AbstractValidator<GetCurrencyWithDetailsQuery>
{
    public GetCurrencyWithDetailsQueryValidator()
    {
        RuleFor(prop => prop.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(query => string.Format(Validations.Required, nameof(query.Id)));
    }
}