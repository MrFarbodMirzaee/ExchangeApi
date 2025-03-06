using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries.GetUserByEmail;

public class GetUserByEmailQueryHandler(IUserService userService, IMapper mapper)
    : IRequestHandler<GetUserByEmailQuery, Response<List<UserDto>>>
{
    public async Task<Response<List<UserDto>>> Handle(GetUserByEmailQuery request, CancellationToken ct)
    {
        Response<List<Domain.Entities.User>> users =
            await userService.FindByCondition(e => e.EmailAddress == request.Email, ct);

        var userMapped = mapper.Map<List<UserDto>>(users.Data);

        return users.Succeeded ? new Response<List<UserDto>>(userMapped) : new Response<List<UserDto>>(users.Message);
    }
}