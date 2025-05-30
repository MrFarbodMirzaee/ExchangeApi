using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.Query.GetAllCurrencyAttributeByPdf;

[Validator]
public class GetAllCurrencyAttributeByPdfQueryValidator : AbstractValidator<GetAllCurrencyAttributeByPdfQuery>
{
    public GetAllCurrencyAttributeByPdfQueryValidator()
    {
        RuleFor(prop => prop.Title)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.Title)));
    }
}