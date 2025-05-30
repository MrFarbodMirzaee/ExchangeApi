using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries.GetExchangeTransactionByCurrencyPair;

[Validator]
public class GetExchangeTransactionByCurrencyPairQueryValidator : AbstractValidator<GetExchangeTransactionByCurrencyPairQuery>
{
    public GetExchangeTransactionByCurrencyPairQueryValidator()
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