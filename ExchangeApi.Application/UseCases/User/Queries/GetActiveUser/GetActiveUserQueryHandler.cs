using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries.GetActiveUser;

public class GetActiveUserQueryHandler(IUserService userService, IMapper mapper)
    : IRequestHandler<GetActiveUserQuery, Response<List<UserDto>>>
{
    public async Task<Response<List<UserDto>>> Handle(GetActiveUserQuery request, CancellationToken ct)
    {
        Response<List<Domain.Entities.User>> userFind = await userService.FindByCondition(A => A.IsActive == true, ct);
        
        var userMapped = mapper.Map<List<UserDto>>(userFind.Data);

        return userFind.Succeeded
            ? new Response<List<UserDto>>(userMapped)
            : new Response<List<UserDto>>(userFind.Message);
    }
}