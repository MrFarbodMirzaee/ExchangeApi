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
        var pageSize = request.PageSize;
        var page = request.Page;
        Response<List<ExChangeApi.Domain.Entities.User>> users = await _userService.GetAllAsync(ct, page, pageSize);

        var userMapped = _mapper.Map<List<UserDto>>(users.Data);

        return users.Succeeded ? new Response<List<UserDto>>(userMapped) : new Response<List<UserDto>>(users.Message);
    }
}
