using ExchangeApi.Application.UseCases.File.Upload;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Controllers.V1;
public class FileController : BaseController
{
    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Upload(UploadFileCommand command, CancellationToken ct) => await SendAsync(command, ct);
}
