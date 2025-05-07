using ExchangeApi.Application.Dtos;
using ExchangeApi.Application.UseCases.Authentication.Login;
using ExchangeApi.Application.UseCases.Authentication.Register;
using ExchangeApi.Domain.Wrappers;

namespace ExchangeApi.Application.Contracts;

public interface IAuthenticationService
{
    Task<Response<AuthenticationResponseDto>> LoginAsync(LogInCommand dto, CancellationToken ct);
    Task<Response<AuthenticationResponseDto>> RegisterAsync(RegisterCommand dto, CancellationToken ct);
}