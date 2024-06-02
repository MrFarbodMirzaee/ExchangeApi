using FluentValidation;

namespace ExchangeApi.Application.UseCases.User.Commands;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(2)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100)
            .WithMessage("Please Enter Valid Name");

        RuleFor(x => x.UserName)
            .NotEmpty()
            .NotNull()
            .MaximumLength(300)
            .WithMessage("User Name must be less than or equal to 20 characters");

        RuleFor(x => x.EmailAddress)
            .NotEmpty()
            .NotNull()
            .EmailAddress()
            .WithMessage("Please Enter Valid Email Address");
        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8)
            .WithMessage("Please Enter Valid Password");
    }
}
