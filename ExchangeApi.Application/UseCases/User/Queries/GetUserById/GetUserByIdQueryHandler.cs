using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries.GetUserById;

public class GetUserByIdQueryHandler(IUserService userService, IMapper mapper)
    : IRequestHandler<GetUserByIdQuery, Response<List<UserDto>>>
{
    public async Task<Response<List<UserDto>>> Handle(GetUserByIdQuery request, CancellationToken ct)
    {
        Response<List<Domain.Entities.User>> userFind =
            await userService.FindByCondition(x => x.Id == request.UserId, ct);

        var user = mapper.Map<List<UserDto>>(userFind.Data);

        return userFind.Succeeded ? new Response<List<UserDto>>(user) : new Response<List<UserDto>>(userFind.Message);
    }
}