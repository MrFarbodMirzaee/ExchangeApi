using ExchangeApi.Application.Dtos;
using ExchangeApi.Application.UseCases.Autentication;
using ExchangeApi.Domain.Wrappers;

namespace ExchangeApi.Application.Contracts;

public interface IAutenticationService
{
    Task<Response<AuthenticationResponseDto>> Login(LogInCommand dto, CancellationToken ct);
    Task<Response<AuthenticationResponseDto>> Register(RegisterCommand dto, CancellationToken ct);
}
