using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries.GetAllExchangeTransactionByPdf;

[Validator]
public class GetAllExchangeTransactionByPdfQueryValidator : AbstractValidator<GetAllExchangeTransactionByPdfQuery>
{
    public GetAllExchangeTransactionByPdfQueryValidator()
    {
        RuleFor(prop => prop.Title)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.Title)))
            .MaximumLength(30)
            .WithMessage(item => string.Format(Validations.GreatherThan, nameof(item.Title),30));
    }
}