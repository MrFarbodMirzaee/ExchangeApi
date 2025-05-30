using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetAllExcahngeRateByPdf;

[Validator]
public class GetAllExchangeRateByPdfQueryValidator : AbstractValidator<GetAllExchangeRateByPdfQuery>
{
    public GetAllExchangeRateByPdfQueryValidator()
    {
        RuleFor(prop => prop.Title)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.Title)));
    }
}