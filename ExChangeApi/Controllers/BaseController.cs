using Asp.Versioning;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Controllers;

[Route("api/{version:apiVersion}/[controller]/[action]")]
[ApiVersion("1.0")]
[ApiController]
public class BaseController : Controller
{
    private ISender _mediateR = null!;
    private ISender Mediator => _mediateR ??= HttpContext.
                    RequestServices
                    .GetRequiredService<ISender>();

    protected async Task<ObjectResult> SendAsync<T>(IRequest<Response<T>> request, CancellationToken ct = default)
    {
        var result = await Mediator.Send(request, ct);
        
        if (result.Succeeded)
        {
            return Ok(result);
        }
        else if (result.Data is null)
        {
            return NotFound(result);
        }
        else if (result.Succeeded is false)
        {
            return BadRequest(result);
        }
        
        return StatusCode(500, "Something went wrong");
    }

    protected async Task<ObjectResult> SendAsync(IRequest<Response<object>> request, CancellationToken ct = default) =>
        await SendAsync<object>(request, ct);

    protected async Task<ObjectResult> SendAsync(IRequest<Response<Guid>> request, CancellationToken ct = default) =>
        await SendAsync<Guid>(request, ct);

    protected async Task<ObjectResult> SendAsync(IRequest<Response<int>> request, CancellationToken ct = default) =>
        await SendAsync<int>(request, ct);

    protected async Task<ObjectResult> SendAsync(IRequest<Response<long>> request, CancellationToken ct = default) =>
        await SendAsync<long>(request, ct);
    
    protected async Task<IActionResult> SendAsync<T>(IRequest<T> request, CancellationToken ct = default)
    {
        var result = await Mediator
                        .Send(request, ct);
        return result switch
        {
            FileResult file => file,
            _ => Ok(result)
        };
    }

    protected async Task<ObjectResult> SendAsync(IRequest<Response<DownloadFileDto>> request,
        CancellationToken ct = default)
    {
        var result =
            await Mediator
            .Send(request, ct);
        
        if (result.Succeeded)
        {
            return Ok(result);
        }
        else if (result.Data is null)
        {
            return NotFound(result);
        }
        else if (result.Succeeded is false)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}