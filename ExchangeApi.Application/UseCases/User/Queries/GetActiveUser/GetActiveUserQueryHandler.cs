using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries;
public class GetActiveUserQueryHandler : IRequestHandler<GetActiveUserQuery, Response<List<UserDto>>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public GetActiveUserQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    public async Task<Response<List<UserDto>>> Handle(GetActiveUserQuery request, CancellationToken ct)
    {

        Response<List<ExChangeApi.Domain.Entities.User>> userFind = await _userService.FindByCondition(A => A.IsActive == true, ct);
        var userMapped = _mapper.Map<List<UserDto>>(userFind.Data);

        return userFind.Succeeded ? new Response<List<UserDto>>(userMapped) : new Response<List<UserDto>>(userFind.Message);
    }
}
