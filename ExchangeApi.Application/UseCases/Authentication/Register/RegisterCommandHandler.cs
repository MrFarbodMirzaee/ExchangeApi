using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Authentication.Register;

public class RegisterCommandHandler(IAuthenticationService authenticationService)
    : IRequestHandler<RegisterCommand, Response<AuthenticationResponseDto>>
{
    public async Task<Response<AuthenticationResponseDto>> Handle(RegisterCommand request, CancellationToken ct)
    {
        var result = await authenticationService.RegisterAsync(request, ct);
        return result.Succeeded
            ? new Response<AuthenticationResponseDto>(result.Data)
            : new Response<AuthenticationResponseDto>(result.Message);
    }
}