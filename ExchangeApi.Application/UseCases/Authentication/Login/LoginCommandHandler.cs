using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.Authentication.Login;

public class LoginCommandHandler(IAuthenticationService authenticationService,
    IValidator<LogInCommand> logInCommandHandler)
    : IRequestHandler<LogInCommand, Response<AuthenticationResponseDto>>
{
    public async Task<Response<AuthenticationResponseDto>> Handle(LogInCommand request, CancellationToken ct)
    {
        await logInCommandHandler
        .ValidateAndThrowAsync(request, ct);
        
        var loggedIn = await 
            authenticationService
            .LoginAsync(request, ct);
        
        return loggedIn.Succeeded
            ? new Response<AuthenticationResponseDto>(loggedIn.Data)
            : new Response<AuthenticationResponseDto>(loggedIn.Message);
    }
}