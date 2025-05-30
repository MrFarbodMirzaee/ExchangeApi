using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetAllCurrencyByPdf;

[Validator]
public class GetAllCurrencyByPdfQueryValidator : AbstractValidator<GetAllCurrencyByPdfQuery>
{
    public GetAllCurrencyByPdfQueryValidator()
    {
        RuleFor(prop => prop.Title)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.Title)));
    }
}