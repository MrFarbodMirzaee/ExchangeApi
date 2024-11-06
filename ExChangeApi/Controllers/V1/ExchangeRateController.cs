using ExchangeApi.Shered;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Mime;
using ExchangeApi.Application.UseCases.ExchangeRate.Commands;
using ExchangeApi.Application.UseCases.ExchangeRate.Queries;
using ExchangeApi.Application.UseCases.ExchangeRate;
using Microsoft.AspNetCore.Authorization;

namespace ExchangeApi.Controllers.V1;
public class ExchangeRateController : BaseController
{
    private readonly MySettings _settings;
    public ExchangeRateController(IOptionsMonitor<MySettings> settings) => _settings = settings.CurrentValue;
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllExchangeRateQuery request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromQuery] GetExchangeRateByIdQuery request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByCurrencyPair([FromQuery] GetExchangeRateByCurrencyPairQuery request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLatest([FromQuery] GetLatestExchangeRateQuery request, CancellationToken ct) => await SendAsync(request, ct);
    [Authorize]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] AddExchagneRateCommand command, CancellationToken ct) => await SendAsync(command, ct);
    [Authorize]
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody]UpdateExchangeRateCommand request, CancellationToken ct) => await SendAsync(request, ct);
    [Authorize]
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(DeleteExchangeRateCommand request, CancellationToken ct) => await SendAsync(request, ct);

}
