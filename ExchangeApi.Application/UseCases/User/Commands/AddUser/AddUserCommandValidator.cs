using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.User.Commands.AddUser;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(2)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "Name"))
            .MaximumLength(100)
            .WithMessage(string.Format(Validations.MaxLength, "Name", 100));

        RuleFor(x => x.UserName)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "UserName"))
            .MaximumLength(300)
            .WithMessage(string.Format(Validations.MaxLength, "UserName", 300));

        RuleFor(x => x.EmailAddress)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "EmailAddress"))
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage(string.Format(Validations.Required, "Password"))
            .MinimumLength(8)
            .WithMessage(string.Format(Validations.MaxLength, "Password", 8));

        RuleFor(x => x.MetaDescription)
          .NotEmpty()
          .NotNull()
          .WithMessage(string.Format(Validations.Required, "MetaDescription"))
          .MinimumLength(8)
          .WithMessage(string.Format(Validations.MaxLength, "MetaDescription",8));

        RuleFor(x => x.IsActive)
          .NotEmpty()
          .NotNull()
          .WithMessage(string.Format(Validations.Required, "IsActive"));
    }
}