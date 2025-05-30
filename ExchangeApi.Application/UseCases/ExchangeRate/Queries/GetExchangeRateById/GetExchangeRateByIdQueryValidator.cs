using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetExchangeRateById;

[Validator]
public class GetExchangeRateByIdQueryValidator : AbstractValidator<GetExchangeRateByIdQuery>
{
    public GetExchangeRateByIdQueryValidator()
    {
        RuleFor(prop => prop.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.Id)));
    }
}