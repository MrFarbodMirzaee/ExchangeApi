using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.User.Commands.AddUser;

[Validator]
public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(2)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.Name)))
            .MaximumLength(100)
            .WithMessage(item =>string.Format(Validations.MaxLength, nameof(item.Name), 100));

        RuleFor(x => x.UserName)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.UserName)))
            .MaximumLength(300)
            .WithMessage(item =>string.Format(Validations.MaxLength, nameof(item.UserName), 300));

        RuleFor(x => x.EmailAddress)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.EmailAddress)))
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage(item =>string.Format(Validations.Required, nameof(item.Password)))
            .MinimumLength(8)
            .WithMessage(item =>string.Format(Validations.MaxLength, nameof(item.Password), 8));

        RuleFor(x => x.MetaDescription)
          .NotEmpty()
          .NotNull()
          .WithMessage(item =>string.Format(Validations.Required, nameof(item.MetaDescription)))
          .MinimumLength(8)
          .WithMessage(item =>string.Format(Validations.MaxLength, nameof(item.MetaDescription),8));

        RuleFor(x => x.IsActive)
          .NotEmpty()
          .NotNull()
          .WithMessage(item =>string.Format(Validations.Required, nameof(item.IsActive)));
    }
}