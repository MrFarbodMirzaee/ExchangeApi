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
        var UserData = _mapper.Map<ExChangeApi.Domain.Entities.User>(request);
        await _userService.AddAsync(UserData, ct);
        return new Response<bool>(true);
    }
}
