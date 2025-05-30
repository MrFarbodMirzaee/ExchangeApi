using DocumentFormat.OpenXml.Spreadsheet;
using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.Currency.Commands.AddCurrency;

[Validator]
public class AddCurrencyCommandValidator : AbstractValidator<AddCurrencyCommand>
{
    public AddCurrencyCommandValidator()
    {
        RuleFor(x => x.CurrencyCode)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.CurrencyCode)))
            .MaximumLength(4)
            .WithMessage(item =>string.Format(Validations.MaxLength, nameof(item.CurrencyCode), 4));

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.Name)))
            .MinimumLength(2)
            .WithMessage(item =>string.Format(Validations.MinLength, nameof(item.Name), 2));

        RuleFor(x => x.Description)
          .NotEmpty()
          .NotNull()
          .WithMessage(item=> string.Format(Validations.Required, nameof(item.Description)))
          .MaximumLength(500)
         .WithMessage(item=> string.Format(Validations.MaxLength, nameof(item.Description), 500));

        RuleFor(x => x.MetaDescription)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.MetaDescription)))
            .MaximumLength(300)
            .WithMessage(item =>string.Format(Validations.MaxLength, nameof(item.MetaDescription), 300));

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .NotNull()
           .WithMessage(item =>string.Format(Validations.Required, nameof(item.CategoryId)));

        RuleFor(x => x.ImagePath)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.ImagePath)))
            .MaximumLength(200)
            .WithMessage(string.Format(Validations.MaxLength, "ImagePath", 200 ));

        RuleFor(x => x.IsActive)
            .NotNull()
            .NotEmpty()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.IsActive)));
    }
}