using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.Authentication.Login;

[Validator]
public class LogInCommandValidator : AbstractValidator<LogInCommand>
{
    public LogInCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.UserName)))
            .MinimumLength(2)
            .WithMessage(item =>string.Format(Validations.MaxLength, nameof(item.UserName),2));

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.Password)))
            .MinimumLength(6)
            .WithMessage(item =>string.Format(Validations.MinLength, nameof(item.Password), 6));
    }
}