using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.Authentication.Register;

[Validator]
public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.UserName)))
            .MinimumLength(2)
            .WithMessage(item =>string.Format(Validations.MinLength, nameof(item.UserName),2));

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.Password)))
            .MinimumLength(6)
            .WithMessage(item =>string.Format(Validations.MinLength, nameof(item.Password),6));

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.FirstName)))
            .MinimumLength(2)
            .WithMessage(item =>string.Format(Validations.MinLength, nameof(item.FirstName),2))
            .MaximumLength(50)
            .WithMessage(item =>string.Format(Validations.MaxLength, nameof(item.FirstName), 50));

        RuleFor(x => x.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.LastName)))
            .MinimumLength(2)
            .WithMessage(item =>string.Format(Validations.MinLength, nameof(item.LastName), 2));
    }
}