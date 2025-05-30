using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.User.Queries.GetUserByEmail;

[Validator]
public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
{
    public GetUserByEmailQueryValidator()
    {
        RuleFor(prop => prop.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage(item => string.Format(Validations.Email, nameof(item.Email)));
    }
}