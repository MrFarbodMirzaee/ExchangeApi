﻿using FluentValidation;

namespace ExchangeApi.Application.Dtos;

public class AddExchangeRateDto
{
    public int FromCurrency { get; set; }
    public int ToCurrency { get; set; }
    public decimal Rate { get; set; }
    public bool IsActive { get; set; }
}
public class AddExchangeRateDtoValidator : AbstractValidator<AddExchangeRateDto>
{
    public AddExchangeRateDtoValidator()
    {
        RuleFor(x => x.FromCurrency)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Please select a valid From Currency");

        RuleFor(x => x.ToCurrency)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Please select a valid To Currency");

        RuleFor(x => x.Rate)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Rate must be greater than 0");
    }
}
