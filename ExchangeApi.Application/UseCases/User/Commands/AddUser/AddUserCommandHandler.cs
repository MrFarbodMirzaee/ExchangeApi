using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Helper;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Commands.AddUser;

public class AddUserCommandHandler(IUserService userService, IMapper mapper)
    : IRequestHandler<AddUserCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(AddUserCommand request, CancellationToken ct)
    {
        byte[] salt = 
            new 
            byte[16];
        request.Password = PasswordHelper
            .HashPasswordWithArgon2
            (request.Password, salt);
            
        var userMapped = mapper
            .Map<Domain.Entities.User>
                (request);

        var userStatus = await 
                userService
                .AddAsync(userMapped, ct);

        return userStatus.Succeeded ?
            new Response<bool>(userStatus.Data) 
            : new Response<bool>(userStatus.Message);
    }
}