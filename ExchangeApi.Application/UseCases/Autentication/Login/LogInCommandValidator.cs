using FluentValidation;

namespace ExchangeApi.Application.UseCases.Autentication;
public class LogInCommandValidator : AbstractValidator<LogInCommand>
{
    public LogInCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("UserName must not be empty and should not less than 3 characters");

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(6)
            .WithMessage("Password not be empty and should have a minimum length of 6 characters");
    }
}
