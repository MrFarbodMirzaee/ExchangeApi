using FluentValidation;

namespace ExchangeApi.Application.Dtos;

public record UpdateUserDto
(
    string Name,
    string UserName,
    string EmailAddress,
    string Password,
    bool IsActive
);

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("Name must not be empty and should have a maximum length of 2 characters");

        RuleFor(x => x.UserName)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("UserName must not be empty and should have a minimum length of 2 characters");
        
        RuleFor(x => x.EmailAddress)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .WithMessage("EmailAddress must not be empty and should have a minimum length of 2 characters");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8)
            .WithMessage("Password must not be empty and should have a minimum length of 8 characters");
        
        RuleFor(x => x.IsActive)
            .NotEmpty()
            .NotNull()
            .WithMessage("Is active has to have value");
    }
}