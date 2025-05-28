using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.Authentication.Login;

public class LogInCommandValidator : AbstractValidator<LogInCommand>
{
    public LogInCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "UserName"))
            .MinimumLength(2)
            .WithMessage(string.Format(Validations.MaxLength, "UserName",2));

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "Password"))
            .MinimumLength(6)
            .WithMessage(string.Format(Validations.MinLength, "Password", 6));
    }
}