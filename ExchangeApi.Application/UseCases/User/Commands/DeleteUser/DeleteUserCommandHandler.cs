using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.UseCases.User.Commands.DeleteUser;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Commands;
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<bool>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public DeleteUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    public async Task<Response<bool>> Handle(DeleteUserCommand request, CancellationToken ct)
    {
        var userFind = await _userService.FindByCondition(x => x.Id == request.Id, ct);
        if (!userFind.Succeeded)
            return new Response<bool>(userFind.Message);

        var user = userFind.Data.FirstOrDefault();

        var deleted = await _userService.DeleteAsync(user, ct);
        
        var UserDto = _mapper.Map<bool>(deleted.Data);
        return deleted.Succeeded ? new Response<bool>(deleted.Data) : new Response<bool>(deleted.Message);
    }
}
