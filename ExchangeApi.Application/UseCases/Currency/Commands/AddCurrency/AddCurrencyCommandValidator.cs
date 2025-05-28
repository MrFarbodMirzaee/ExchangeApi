using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.Currency.Commands.AddCurrency;

public class AddCurrencyCommandValidator : AbstractValidator<AddCurrencyCommand>
{
    public AddCurrencyCommandValidator()
    {
        RuleFor(x => x.CurrencyCode)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "CurrencyCode"))
            .MaximumLength(4)
            .WithMessage(string.Format(Validations.MaxLength, "CurrencyCode", 4));

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "Name"))
            .MinimumLength(2)
            .WithMessage(string.Format(Validations.MinLength, "Name", 2));

        RuleFor(x => x.Description)
          .NotEmpty()
          .NotNull()
          .WithMessage(string.Format(Validations.Required, "Description"))
          .MaximumLength(500)
         .WithMessage(string.Format(Validations.MaxLength, "Description", 500));

        RuleFor(x => x.MetaDescription)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "MetaDescription"))
            .MaximumLength(300)
            .WithMessage(string.Format(Validations.MaxLength, "MetaDescription", 300));

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .NotNull()
           .WithMessage(string.Format(Validations.Required, "CategoryId"));

        RuleFor(x => x.ImagePath)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "ImagePath"))
            .MaximumLength(200)
            .WithMessage(string.Format(Validations.MaxLength, "ImagePath", 200 ));

        RuleFor(x => x.IsActive)
            .NotNull()
            .NotEmpty()
            .WithMessage(string.Format(Validations.Required, "IsActive"));
    }
}