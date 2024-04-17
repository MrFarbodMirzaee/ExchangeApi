using FluentValidation;

namespace ExchangeApi.Application.Dtos;

public class AddExchangeTransactionDto
{
    public int FromCurrencyId { get; set; }
    public int ToCurrencyId { get; set; }
    public decimal Amount { get; set; }
    public decimal ResultAmount { get; set; }
    public int ExchangeRateId { get; set; }
    public bool IsActive { get; set; }
    public DateTime TransactionDate { get; set; }
}
public class AddExchangeTransactionDtoValidator : AbstractValidator<AddExchangeTransactionDto>
{
    public AddExchangeTransactionDtoValidator()
    {
        RuleFor(x => x.FromCurrencyId)  
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Please select a valid From Currency");

        RuleFor(x => x.ToCurrencyId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Please select a valid To Currency");

        RuleFor(x => x.Amount)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Amount must be greater than 0");

        RuleFor(x => x.ResultAmount)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Result Amount must be greater than 0");

        RuleFor(x => x.ExchangeRateId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Please select a valid Exchange Rate");

        RuleFor(x => x.TransactionDate)
            .NotEmpty()
            .NotNull()
            .WithMessage("Transaction Date cannot be in the future");
    }
}
