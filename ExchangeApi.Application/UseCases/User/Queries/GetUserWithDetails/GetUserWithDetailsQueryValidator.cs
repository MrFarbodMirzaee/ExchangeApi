using ExchangeApi.Application.Attributes;
using FluentValidation;
using ResourceApi.Messages;

namespace ExchangeApi.Application.UseCases.User.Queries.GetUserWithDetails;

[Validator]
public class GetUserWithDetailsQueryValidator : AbstractValidator<GetUserWithDetailsQuery>
{
    public GetUserWithDetailsQueryValidator()
    {
        RuleFor(prop => prop.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(item => string.Format(Validations.Required, nameof(item.Id)));
    }
}