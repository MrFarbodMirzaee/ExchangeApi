using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Commands.DeleteUser;

public class DeleteUserCommandHandler(IUserService userService, IMapper mapper)
    : IRequestHandler<DeleteUserCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(DeleteUserCommand request, CancellationToken ct)
    {
        var userFind = await userService.FindByCondition(x => x.Id == request.Id, ct);
        if (!userFind.Succeeded)
            return new Response<bool>(userFind.Message);

        var user = userFind.Data.FirstOrDefault();

        var deleted = await userService.DeleteAsync(user, ct);

        var UserDto = mapper.Map<bool>(deleted.Data);
        return deleted.Succeeded ? new Response<bool>(deleted.Data) : new Response<bool>(deleted.Message);
    }
}