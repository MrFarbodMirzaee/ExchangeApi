using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Autentication;
public class LogInCommandHandler : IRequestHandler<LogInCommand, Response<AuthenticationResponseDto>>
{
    private readonly IAutenticationService _autenticationService;
    public LogInCommandHandler(IAutenticationService autenticationService) => _autenticationService = autenticationService;
    public async Task<Response<AuthenticationResponseDto>> Handle(LogInCommand request, CancellationToken ct)
    {
        var logedIn = await _autenticationService.Login(request, ct);
        return logedIn.Succeeded ? new Response<AuthenticationResponseDto>(logedIn.Data) : new Response<AuthenticationResponseDto>(logedIn.Message);
    }
}
