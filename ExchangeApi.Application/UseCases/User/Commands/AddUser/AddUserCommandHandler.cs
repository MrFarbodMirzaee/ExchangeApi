using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Commands;
public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Response<bool>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public AddUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    public async Task<Response<bool>> Handle(AddUserCommand request, CancellationToken ct)
    {
        var userMapped = _mapper.Map<ExChangeApi.Domain.Entities.User>(request);

        var userStatus = await _userService.AddAsync(userMapped, ct);

        return userStatus.Succeeded ? new Response<bool>(userStatus.Data) : new Response<bool>(userStatus.Message);
    }
}
