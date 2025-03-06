using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Authentication.Login;

public class LoginCommandHandler(IAuthenticationService authenticationService)
    : IRequestHandler<LogInCommand, Response<AuthenticationResponseDto>>
{
    public async Task<Response<AuthenticationResponseDto>> Handle(LogInCommand request, CancellationToken ct)
    {
        var loggedIn = await authenticationService.Login(request, ct);
        return loggedIn.Succeeded
            ? new Response<AuthenticationResponseDto>(loggedIn.Data)
            : new Response<AuthenticationResponseDto>(loggedIn.Message);
    }
}