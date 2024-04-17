using FluentValidation;

namespace ExchangeApi.Application.Dtos;

public class AddUserDto
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set;}
    public bool IsActive { get; set; }
}
public class AddUserDtoValidator : AbstractValidator<AddUserDto>
{
    public AddUserDtoValidator()
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