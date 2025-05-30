using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries.GetUserById;

public class GetUserByIdQueryHandler(IUserService userService,
    IValidator<GetUserByIdQuery>getUserByIdQueryValidator,
    IMapper mapper)
    : IRequestHandler<GetUserByIdQuery, Response<List<UserDto>>>
{
    public async Task<Response<List<UserDto>>> Handle(GetUserByIdQuery request, CancellationToken ct)
    {
        await getUserByIdQueryValidator
        .ValidateAndThrowAsync(request, ct);
        
        var userFind =
        await userService
        .FindByCondition(x => x.Id == request.UserId, ct);

        var user = mapper
            .Map<List<UserDto>>
            (userFind.Data);

        return userFind.Succeeded 
            ? new Response<List<UserDto>>(user) 
            : new Response<List<UserDto>>(userFind.Message);
    }
}