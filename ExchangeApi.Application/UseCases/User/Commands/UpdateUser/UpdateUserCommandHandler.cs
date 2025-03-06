using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Commands.UpdateUser;

public class UpdateUserCommandHandler(IUserService userService, IMapper mapper) : IRequestHandler<UpdateUserCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(UpdateUserCommand request, CancellationToken ct)
    {
        var userEntity = mapper.Map<Domain.Entities.User>(request.UpdateUserDto);
        
        userEntity.Id = request.Id;
        userEntity.Updated = DateTime.Now;

        var userStatus = await userService.UpdateAsync(userEntity, ct);

        return userStatus.Succeeded ? new Response<bool>(userStatus.Data) : new Response<bool>(userStatus.Message);
    }
}