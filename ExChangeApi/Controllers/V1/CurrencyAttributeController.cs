using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using ExchangeApi.Application.UseCases.CurrencyAttribute.AddAttributes;
using ExchangeApi.Application.UseCases.CurrencyAttribute.GetAllCurrencyAttributeInExcelFormatQuery;
using ExchangeApi.Application.UseCases.CurrencyAttribute.UploadCurrencyAttributeByExcle;

namespace ExchangeApi.Controllers.V1;

public class CurrencyAttributeController : BaseController
{
    [Authorize]
    [Route("")]
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
    public async Task<IActionResult> AddByExcel([FromForm] UploadCurrencyAttributeByExcleCommand command, CancellationToken ct) =>
        await SendAsync(command, ct);
    
     [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllInExcleFormat([FromQuery] GetAllCurrencyAttributeInExcelFormatQuery request, CancellationToken ct) =>
            await SendAsync(request, ct);
}