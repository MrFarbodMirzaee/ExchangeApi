using Asp.Versioning;
using ExchangeApi.Domain.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/{version:apiVersion}/[controller]/[action]")]
[ApiVersion("1.0")]
[ApiController]
public class BaseController : Controller
{
    private ISender _mediateR;
    private ISender Mediator => _mediateR ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    protected async Task<ObjectResult> SendAsync<T>(IRequest<Response<T>> request, CancellationToken ct = default)
    {
        var result = await Mediator.Send(request, ct);
        if (result.Succeeded)
        {
            return Ok(result);
        }

        return Ok(result);
    }
    protected async Task<ObjectResult> SendAsync(IRequest<Response<object>> request, CancellationToken ct = default) => await SendAsync<object>(request, ct);
    protected async Task<ObjectResult> SendAsync(IRequest<Response<Guid>> request, CancellationToken ct = default) => await SendAsync<Guid>(request, ct);
    protected async Task<ObjectResult> SendAsync(IRequest<Response<int>> request, CancellationToken ct = default) => await SendAsync<int>(request, ct);
    protected async Task<ObjectResult> SendAsync(IRequest<Response<long>> request, CancellationToken ct = default) => await SendAsync<long>(request, ct);
   

}
