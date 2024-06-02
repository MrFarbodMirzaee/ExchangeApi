using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, Response<List<UserDto>>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public GetAllUserQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    public async Task<Response<List<UserDto>>> Handle(GetAllUserQuery request, CancellationToken ct)
    {

        Response<List<ExChangeApi.Domain.Entities.User>> data = await _userService.GetAllAsync(ct);
        var UserDto = _mapper.Map<List<UserDto>>(data);
        return new Response<List<UserDto>>(UserDto);
    }
}
