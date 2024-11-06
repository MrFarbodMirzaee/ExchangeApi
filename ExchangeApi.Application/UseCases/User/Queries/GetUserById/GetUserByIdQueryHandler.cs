using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries;
public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response<List<UserDto>>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public GetUserByIdQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    public async Task<Response<List<UserDto>>> Handle(GetUserByIdQuery request, CancellationToken ct)
    {
        Response<List<ExChangeApi.Domain.Entities.User>> userFind = await _userService.FindByCondition(x => x.Id == request.UserId, ct);
       
        var user = _mapper.Map<List<UserDto>>(userFind.Data);
       
        return userFind.Succeeded ? new Response<List<UserDto>>(user) : new Response<List<UserDto>>(userFind.Message);
    }
}
