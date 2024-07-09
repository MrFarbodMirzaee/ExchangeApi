
using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.UseCases.User.Commands.DeleteUser;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<int>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public DeleteUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    public async Task<Response<int>> Handle(DeleteUserCommand request, CancellationToken ct)
    {
        var UserResponse = await _userService.FindByCondition(x => x.Id == request.Id, ct);
        if (!UserResponse.Succeeded)
        {
            // Handle the case where the currency was not found
            return new Response<int>(0,"User not found");
        }

        var user = UserResponse.Data.FirstOrDefault();

        var data = await _userService.DeleteAsync(user, ct);
        if (!data.Succeeded)
        {
            // Handle the case where the delete operation failed
            return new Response<int>(0,"Something unexpected happened");
        }
        var UserDto = _mapper.Map<bool>(data.Data);
        return new Response<int>(1);
    }
}
