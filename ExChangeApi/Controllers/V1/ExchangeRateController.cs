using ExchangeApi.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Mime;
using ExchangeApi.Application.UseCases.ExchangeRate.Commands.AddExchangeRate;
using ExchangeApi.Application.UseCases.ExchangeRate.Commands.DeleteExchangeRate;
using ExchangeApi.Application.UseCases.ExchangeRate.Commands.UpdateExchangeRate;
using ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetAllExcahngeRateByPdf;
using ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetAllExchangeRate;
using ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetAllExchangeRateInExcelFormatQuery;
using ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetExchangeRateByCurrencyPair;
using ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetExchangeRateById;
using ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetLatestExchangeRate;
using Microsoft.AspNetCore.Authorization;

namespace ExchangeApi.Controllers.V1;

public class ExchangeRateController(IOptionsMonitor<MySettings> settings) : BaseController
{
    private readonly MySettings
        _settings = settings
            .CurrentValue; // I write this just because of showing OptionBuilder Pattern, but it is useless in my project

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromBody] GetAllExchangeRateQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllByPdf([FromQuery] GetAllExchangeRateByPdfQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);
    
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromQuery] GetExchangeRateByIdQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);
    
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllInExcleFormat([FromQuery] GetAllExchangeRateInExcelFormatQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByCurrencyPair([FromQuery] GetExchangeRateByCurrencyPairQuery request,
        CancellationToken ct) => await SendAsync(request, ct);

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLatest([FromQuery] GetLatestExchangeRateQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);

    [Authorize]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] AddExchangeRateCommand command, CancellationToken ct) =>
        await SendAsync(command, ct);

    [Authorize]
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] UpdateExchangeRateCommand request, CancellationToken ct) =>
        await SendAsync(request, ct);

    [Authorize]
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(DeleteExchangeRateCommand request, CancellationToken ct) =>
        await SendAsync(request, ct);
}