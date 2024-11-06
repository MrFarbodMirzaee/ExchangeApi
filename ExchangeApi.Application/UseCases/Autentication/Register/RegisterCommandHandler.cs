using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Autentication.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response<AuthenticationResponseDto>>
{
    private readonly IAutenticationService _autenticationService;
    public RegisterCommandHandler(IAutenticationService autenticationService) => _autenticationService = autenticationService;
    public async Task<Response<AuthenticationResponseDto>> Handle(RegisterCommand request, CancellationToken ct)
    {
        var result = await _autenticationService.Register(request, ct);
        return result.Succeeded ? new Response<AuthenticationResponseDto>(result.Data) : new Response<AuthenticationResponseDto>(result.Message);
    }
}
