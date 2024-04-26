using AutoMapper;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ExchangeApi.Controllers.V1;

public class AutenticationController : BaseController
{
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginDto dto,CancellationToken ct)
    {
        return Created();
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto, CancellationToken ct)
    {
        return Created();
    }
}
