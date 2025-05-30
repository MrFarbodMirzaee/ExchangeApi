using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.User.Queries.SearchUser;

[Validator]
public class SearchUserQueryValidator : AbstractValidator<SearchUserQuery>
{
    public SearchUserQueryValidator()
    {
        RuleFor(prop => prop.Name)
            .MaximumLength(50)
            .WithMessage(item => string.Format(Validations.MaxLength, nameof(item.Name),50))
            .MinimumLength(2)
            .WithMessage(item => string.Format(Validations.MinLength, nameof(item.Name),2));
        
        RuleFor(prop => prop.UserName)
            .MaximumLength(150)
            .WithMessage(item => string.Format(Validations.MaxLength, nameof(item.UserName),150))
            .MinimumLength(2)
            .WithMessage(item => string.Format(Validations.MinLength, nameof(item.UserName),2));
        
        RuleFor(prop => prop.EmailAddress)
            .EmailAddress()
            .WithMessage(item => string.Format(Validations.Email, nameof(item.EmailAddress)));
    }
}