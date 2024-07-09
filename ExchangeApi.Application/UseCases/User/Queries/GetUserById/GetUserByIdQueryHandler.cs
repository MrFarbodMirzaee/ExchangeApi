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
        Response<List<ExChangeApi.Domain.Entities.User>> data = await _userService.FindByCondition(x => x.Id == request.UserId, ct);
        if (data == null)
            return new Response<List<UserDto>>(new List<UserDto>());

        var user = _mapper.Map<List<UserDto>>(data.Data);
        return new Response<List<UserDto>>(new List<UserDto>(user));
    }
}
