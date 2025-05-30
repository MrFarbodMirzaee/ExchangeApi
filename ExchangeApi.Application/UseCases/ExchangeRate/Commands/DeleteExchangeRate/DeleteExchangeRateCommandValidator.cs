using ExchangeApi.Application.Attributes;
using FluentValidation;
using Microsoft.VisualBasic;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands.DeleteExchangeRate;

[Validator]
public class DeleteExchangeRateCommandValidator : AbstractValidator<DeleteExchangeRateCommand>
{
    public DeleteExchangeRateCommandValidator()
    {
        RuleFor(prop => prop.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage(item=> Strings.Format(Validations.Required,nameof(item.Id)));
    }
}