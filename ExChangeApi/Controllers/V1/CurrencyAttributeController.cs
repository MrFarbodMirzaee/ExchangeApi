using ExchangeApi.Application.UseCases.CurrencyAttribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ExchangeApi.Controllers.V1;
public class CurrencyAttributeController : BaseController
{
    [Authorize]
    [Route("")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCurrencyAttrbutes([FromBody] AddAttributeCommand addAttributeCommand, CancellationToken ct) => await SendAsync(addAttributeCommand, ct);
}
