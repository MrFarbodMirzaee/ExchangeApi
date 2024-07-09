using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;

namespace ExchangeApi.Application.Contracts;

public interface IAutenticationService
{
    Task<Response<AuthenticationResponseDto>> Login(LoginDto dto, CancellationToken ct);
    Task<Response<AuthenticationResponseDto>> Register(RegisterDto dto, CancellationToken ct);
}
