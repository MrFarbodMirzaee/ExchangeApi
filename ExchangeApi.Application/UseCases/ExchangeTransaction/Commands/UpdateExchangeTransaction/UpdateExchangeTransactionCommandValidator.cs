using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.UpdateExchangeTransaction;

[Validator]
public class UpdateExchangeTransactionCommandValidator : AbstractValidator<UpdateExchangeTransactionCommand>
{
    public UpdateExchangeTransactionCommandValidator()
    {
        RuleFor(prop => prop.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(item=> 
            string.Format(Validations.Required,nameof(item.Id)));
        
        RuleFor(prop => prop.UpdateExchangeTransactionDto.FromCurrencyId)
            .NotEmpty()
            .NotNull()
            .WithMessage(item=> string.Format
            (Validations.Required,nameof
            (item.UpdateExchangeTransactionDto.FromCurrencyId)));

        RuleFor(prop => prop.UpdateExchangeTransactionDto.ToCurrencyId)
            .NotEmpty()
            .NotNull()
            .WithMessage(item=> string.Format
            (Validations.Required,
            nameof(item.UpdateExchangeTransactionDto.ToCurrencyId)));
        
        RuleFor(prop => prop.UpdateExchangeTransactionDto.Amount)
            .NotEmpty()
            .NotNull()
            .WithMessage(item=> string.Format
            (Validations.Required,
            nameof(item.UpdateExchangeTransactionDto.Amount)))
            .GreaterThan(0)
            .WithMessage(item=> string.Format
            (Validations.GreatherThan,nameof(item.UpdateExchangeTransactionDto.Amount),0));

        RuleFor(prop => prop.UpdateExchangeTransactionDto.ExchangeRateId)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>
            string.Format(Validations.Required,
            nameof(item.UpdateExchangeTransactionDto.ExchangeRateId)));
        
        RuleFor(prop => prop.UpdateExchangeTransactionDto.ResultAmount)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>
                string.Format(Validations.Required,
                nameof(item.UpdateExchangeTransactionDto.ResultAmount)))
            .GreaterThan(0)
            .WithMessage(item=> string.Format
            (Validations.GreatherThan,
            nameof(item.UpdateExchangeTransactionDto.ResultAmount),0));

        RuleFor(prop => prop.UpdateExchangeTransactionDto.TransactionDate)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>
            string.Format(Validations.Required,
            nameof(item.UpdateExchangeTransactionDto.TransactionDate)));

        RuleFor(prop => prop.UpdateExchangeTransactionDto.IsActive)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>
            string.Format(Validations.Required,
            nameof(item.UpdateExchangeTransactionDto.IsActive)));
    }
}