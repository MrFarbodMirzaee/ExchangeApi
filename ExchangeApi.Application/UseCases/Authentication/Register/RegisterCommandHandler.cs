using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.Authentication.Register;

public class RegisterCommandHandler(IAuthenticationService authenticationService,
    IValidator<RegisterCommand> registerCommandValidator)
    : IRequestHandler<RegisterCommand, Response<AuthenticationResponseDto>>
{
    public async Task<Response<AuthenticationResponseDto>> Handle(RegisterCommand request, CancellationToken ct)
    {
       await registerCommandValidator
        .ValidateAndThrowAsync(request, ct);
        
        var result = await 
            authenticationService
            .RegisterAsync(request, ct);
        
        return result.Succeeded
            ? new Response<AuthenticationResponseDto>(result.Data)
            : new Response<AuthenticationResponseDto>(result.Message);
    }
}