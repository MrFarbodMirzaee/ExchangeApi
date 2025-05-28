using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.Authentication.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "UserName"))
            .MinimumLength(2)
            .WithMessage(string.Format(Validations.MinLength, "UserName",2));

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "Password"))
            .MinimumLength(6)
            .WithMessage(string.Format(Validations.MinLength, "Password",6));

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "FirstName"))
            .MinimumLength(2)
            .WithMessage(string.Format(Validations.MinLength, "FirstName",2))
            .MaximumLength(50)
            .WithMessage(string.Format(Validations.MaxLength, "FirstName", 50));

        RuleFor(x => x.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "LastName"))
            .MinimumLength(2)
            .WithMessage(string.Format(Validations.MinLength, "LastName", 2));
    }
}