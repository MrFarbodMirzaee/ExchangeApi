using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Authentication.Login;

public record LogInCommand : IRequest<Response<AuthenticationResponseDto>>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}