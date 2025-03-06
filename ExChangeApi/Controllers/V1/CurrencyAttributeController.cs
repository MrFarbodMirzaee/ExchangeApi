using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using ExchangeApi.Application.UseCases.CurrencyAttribute.AddAttributes;

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
}