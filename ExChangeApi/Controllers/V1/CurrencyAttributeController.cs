using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using ExchangeApi.Application.UseCases.CurrencyAttribute.Commands.AddAttributes;
using ExchangeApi.Application.UseCases.CurrencyAttribute.Commands.UploadCurrencyAttributeByExcel;
using ExchangeApi.Application.UseCases.CurrencyAttribute.Query.GetAllCurrencyAttributeByPdf;
using ExchangeApi.Application.UseCases.CurrencyAttribute.Query.GetAllCurrencyAttributeInExcelFormatQuery;

namespace ExchangeApi.Controllers.V1;

public class CurrencyAttributeController : BaseController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllInExcelFormat([FromQuery] GetAllCurrencyAttributeInExcelFormatQuery request,
        CancellationToken ct) =>
        await SendAsync(request, ct);

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllByPdf([FromQuery] GetAllCurrencyAttributeByPdfQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);

    [Authorize]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCurrencyAttributes([FromBody] AddAttributeCommand addAttributeCommand,
        CancellationToken ct) => await SendAsync(addAttributeCommand, ct);

    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddByExcel([FromForm] UploadCurrencyAttributeByExcelCommand command,
        CancellationToken ct) =>
        await SendAsync(command, ct);
}