using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ExchangeApi.Shared;
using System.Net.Mime;
using ExchangeApi.Application.UseCases.Currency.Commands.AddCurrency;
using ExchangeApi.Application.UseCases.Currency.Commands.DeleteCurrency;
using ExchangeApi.Application.UseCases.Currency.Commands.UpdateCurrency;
using ExchangeApi.Application.UseCases.Currency.Queries.GetActiveCurrency;
using ExchangeApi.Application.UseCases.Currency.Queries.GetAllCurrency;
using ExchangeApi.Application.UseCases.Currency.Queries.GetCurrencyById;
using ExchangeApi.Application.UseCases.Currency.Queries.SearchCurrency;
using Microsoft.AspNetCore.Authorization;

namespace ExchangeApi.Controllers.V1;

public class CurrencyController(IOptionsMonitor<MySettings> settings) : BaseController
{
    private readonly MySettings
        _settings = settings
            .CurrentValue; // I write this just because of showing OptionBuilder Pattern, but it is useless in my project

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCurrencyQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetActive([FromQuery] GetCurrencyActiveQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromQuery] GetCurrencyByIdQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);

    [Authorize]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddCurrencyCommand command, CancellationToken ct) =>
        await SendAsync(command, ct);

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Search([FromBody] SearchCurrencyQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);

    [Authorize]
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromBody] UpdateCurrencyCommand request, CancellationToken ct) =>
        await SendAsync(request, ct);

    [Authorize]
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromBody] DeleteCurrencyCommand request, CancellationToken ct) =>
        await SendAsync(request, ct);
}