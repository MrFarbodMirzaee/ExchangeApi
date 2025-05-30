using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.User.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(prop => prop.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.Id)));
        
        RuleFor(prop => prop.UpdateUserDto.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.UpdateUserDto.Name)))
            .MinimumLength(2)
            .WithMessage(item => string.Format(Validations.MinLength, nameof(item.UpdateUserDto.Name),2))
            .MaximumLength(50)
            .WithMessage(item => string.Format(Validations.MaxLength, nameof(item.UpdateUserDto.Name),50));

        RuleFor(prop => prop.UpdateUserDto.UserName)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.UpdateUserDto.UserName)))
            .MinimumLength(2)
            .WithMessage(item => string.Format(Validations.MinLength, nameof(item.UpdateUserDto.UserName),2))
            .MaximumLength(50)
            .WithMessage(item => string.Format(Validations.MaxLength, nameof(item.UpdateUserDto.UserName),150));

        RuleFor(prop => prop.UpdateUserDto.EmailAddress)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.UpdateUserDto.EmailAddress)))
            .EmailAddress()
            .WithMessage(item => string.Format(Validations.Email, nameof(item.UpdateUserDto.EmailAddress)));
        
        RuleFor(prop => prop.UpdateUserDto.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.UpdateUserDto.Password)))
            .MinimumLength(8)
            .WithMessage(item => string.Format(Validations.GreatherThan, nameof(item.UpdateUserDto.Password),8));
        
        RuleFor(prop => prop.UpdateUserDto.IsActive)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.UpdateUserDto.IsActive)));
    }
}