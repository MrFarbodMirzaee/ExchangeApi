using FluentValidation;

namespace ExchangeApi.Application.Dtos;

public record UpdateExchangeTransactionDto(
    Guid FromCurrencyId,
    Guid ToCurrencyId,
    decimal Amount,
    decimal ResultAmount,
    Guid ExchangeRateId,
    bool IsActive,
    DateTime TransactionDate
);

public class UpdateExchangeTransactionDtoValidator : AbstractValidator<UpdateExchangeTransactionDto>
{
    public UpdateExchangeTransactionDtoValidator()
    {
        RuleFor(x => x.FromCurrencyId)
            .NotEmpty()
            .NotNull()
            .WithMessage("FromCurrencyId must not be empty");

        RuleFor(x => x.ToCurrencyId)
            .NotEmpty()
            .NotNull()
            .WithMessage("ToCurrencyId must not be empty ");
        
        RuleFor(x => x.Amount)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Amount must not be empty and should be greater than 0");
        
        RuleFor(x => x.ExchangeRateId)
            .NotEmpty()
            .NotNull()
            .WithMessage("ExchangeRateId must not be empty ");
        
        RuleFor(x => x.ResultAmount)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("ResultAmount must not be empty and should be greater than 0");
        
        RuleFor(x => x.TransactionDate)
            .NotEmpty()
            .NotNull()
            .WithMessage("TransactionDate must not be empty");

        RuleFor(x => x.IsActive)
            .NotEmpty()
            .NotNull()
            .WithMessage("Is active has to have value");
    }
}