using Microsoft.AspNetCore.Mvc;
using ExchangeApi.Shered;
using Microsoft.Extensions.Options;
using System.Net.Mime;
using ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.AddExchangeTransaction;
using ExchangeApi.Application.UseCases.ExchangeTransaction.Queries;
using ExchangeApi.Application.UseCases.ExchangeTransaction.Commands;
using Microsoft.AspNetCore.Authorization;

namespace ExchangeApi.Controllers.V1;
public class ExchangeTransactionController : BaseController
{
    private readonly MySettings _settings;
    public ExchangeTransactionController(IOptionsMonitor<MySettings> settings) => _settings = settings.CurrentValue;

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllExchangeTransactionQuery request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromQuery] GetExchangeTransactionByIdQuery request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByCurrencyPair([FromQuery] GetExchangeTransactionByCurrencyPairQuery request, CancellationToken ct) => await SendAsync(request, ct);
    [Authorize]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add(AddExchangeTransactionCommand command, CancellationToken ct) => await SendAsync(command, ct);
    [Authorize]
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(UpdateExchangeTransactionCommand request, CancellationToken ct) => await SendAsync(request, ct);
    [Authorize]
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(DeleteExchangeTransactionCommand request, CancellationToken ct) => await SendAsync(request, ct);
}
