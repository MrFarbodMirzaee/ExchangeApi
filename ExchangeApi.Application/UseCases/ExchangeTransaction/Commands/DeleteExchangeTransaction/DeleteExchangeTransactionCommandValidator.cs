using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.DeleteExchangeTransaction;

[Validator]
public class DeleteExchangeTransactionCommandValidator : AbstractValidator<DeleteExchangeTransactionCommand>
{
    public DeleteExchangeTransactionCommandValidator()
    {
        RuleFor(prop => prop.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage(item=> string.Format(Validations.Required,nameof(item.Id)));
    }
}