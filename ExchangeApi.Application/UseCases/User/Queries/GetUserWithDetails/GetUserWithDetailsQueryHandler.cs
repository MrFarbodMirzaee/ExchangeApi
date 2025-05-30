using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries.GetUserWithDetails;

public class GetUserWithDetailsQueryHandler(IUserService service,
    IValidator<GetUserWithDetailsQuery>getUserWithDetailsQueryValidator) 
    : IRequestHandler<GetUserWithDetailsQuery, Response<UserDetailDto>>
{
    public async Task<Response<UserDetailDto>> Handle(GetUserWithDetailsQuery request, CancellationToken ct)
    {
        await getUserWithDetailsQueryValidator
        .ValidateAndThrowAsync(request, ct);
        
        var userDetailsAsync = await service
            .GetUserDetailsAsync(request,ct);

        return userDetailsAsync.Succeeded
            ? new Response<UserDetailDto>(userDetailsAsync.Data)
            : new Response<UserDetailDto>(userDetailsAsync.Message);
    }
}

