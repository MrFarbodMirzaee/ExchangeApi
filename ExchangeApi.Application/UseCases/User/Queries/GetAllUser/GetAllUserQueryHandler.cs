using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries.GetAllUser;

public class GetAllUserQueryHandler(IUserService userService, IMapper mapper)
    : IRequestHandler<GetAllUserQuery, Response<List<UserDto>>>
{
    public async Task<Response<List<UserDto>>> Handle(GetAllUserQuery request, CancellationToken ct)
    {
        var users = await userService
                                .FindByQueryCriteria
                                (request.QueryCriteria,ct);

        var userMapped = mapper
                .Map<List<UserDto>> 
                (users.Data);

        return users.Succeeded ? 
            new Response<List<UserDto>>
                    (userMapped)
            : new Response<List<UserDto>>
                    (users.Message);
    }
}