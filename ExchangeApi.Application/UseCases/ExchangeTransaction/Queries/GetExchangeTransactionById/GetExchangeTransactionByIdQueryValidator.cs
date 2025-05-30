using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries.GetExchangeTransactionById;

[Validator]
public class GetExchangeTransactionByIdQueryValidator : AbstractValidator<GetExchangeTransactionByIdQuery>
{
    public GetExchangeTransactionByIdQueryValidator()
    {
        RuleFor(prop => prop.ExchangeTransactionId)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.ExchangeTransactionId)));
    }
}