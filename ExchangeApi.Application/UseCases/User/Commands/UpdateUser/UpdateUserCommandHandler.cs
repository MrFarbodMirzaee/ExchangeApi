using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Commands;
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<bool>>
{
    private readonly IUserService _userService;
    public UpdateUserCommandHandler(IUserService userService, IMapper mapper) => _userService = userService;
    
    public async Task<Response<bool>> Handle(UpdateUserCommand request, CancellationToken ct)
    {
        request.User.Id = request.Id;
        request.User.Updated = DateTime.Now;

        var userStatus = await _userService.UpdateAsync(request.User, ct);

        return userStatus.Succeeded ? new Response<bool>(userStatus.Data) : new Response<bool>(userStatus.Message);
    }
}
