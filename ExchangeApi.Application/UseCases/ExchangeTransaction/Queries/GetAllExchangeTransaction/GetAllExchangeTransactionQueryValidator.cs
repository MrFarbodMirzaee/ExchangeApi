using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries.GetAllExchangeTransaction;

[Validator]
public class GetAllExchangeTransactionQueryValidator : AbstractValidator<GetAllExchangeTransactionQuery>
{
    public GetAllExchangeTransactionQueryValidator()
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