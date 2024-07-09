using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ExchangeApi.Controllers.V1;

public class AutenticationController : BaseController
{
    private readonly IAutenticationService _autenticationService;
    public AutenticationController(IAutenticationService autenticationService) 
    {
        _autenticationService = autenticationService;

    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginDto dto,CancellationToken ct)
    {
        var result = await _autenticationService.Login(dto,ct);
        return Ok(result);
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto, CancellationToken ct)
    {
        var result = await _autenticationService.Register(dto, ct);
        return Created();
    }
}
