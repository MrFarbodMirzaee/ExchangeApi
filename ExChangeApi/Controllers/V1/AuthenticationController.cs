using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using ExchangeApi.Application.UseCases.Authentication.Login;
using ExchangeApi.Application.UseCases.Authentication.Register;

namespace ExchangeApi.Controllers.V1;

public class AuthenticationController : BaseController
{
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LogInCommand logInCommand, CancellationToken ct) =>
        await SendAsync(logInCommand, ct);

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand, CancellationToken ct) =>
        await SendAsync(registerCommand, ct);
}