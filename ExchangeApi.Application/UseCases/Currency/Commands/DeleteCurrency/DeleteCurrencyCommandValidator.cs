using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.Currency.Commands.DeleteCurrency;

[Validator]
public class DeleteCurrencyCommandValidator : AbstractValidator<DeleteCurrencyCommand>
{
    public DeleteCurrencyCommandValidator()
    {
        RuleFor(prop => prop.CurrencyId)
            .NotNull()
            .NotEmpty()
            .WithMessage(item=> string.Format(Validations.Required,nameof(item.CurrencyId)));
    }
}