﻿using FluentValidation;

namespace ExchangeApi.Application.Dtos;

public record AddExchangeRateDto(
    Guid FromCurrency,
    Guid ToCurrency,
    decimal Rate,
    bool IsActive
);

public class AddExchangeRateDtoValidator : AbstractValidator<AddExchangeRateDto>
{
    public AddExchangeRateDtoValidator()
    {
        RuleFor(x => x.FromCurrency)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please select a valid From Currency");

        RuleFor(x => x.ToCurrency)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please select a valid To Currency");

        RuleFor(x => x.Rate)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Rate must be greater than 0");

        RuleFor(x => x.IsActive)
            .NotEmpty()
            .NotNull()
            .WithMessage("Is active has to have value");
    }
}