using ExchangeApi.Application.Dtos;
using ExchangeApi.Application.UseCases.File.Download;
using ExchangeApi.Application.UseCases.File.Upload;
using ExchangeApi.Domain.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Controllers.V1;

public class FileController : BaseController
{
    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Upload(UploadFileCommand command, CancellationToken ct) =>
        await SendAsync(command, ct);

    [Authorize]
    [HttpGet("download")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Download([FromQuery] Guid fileId, CancellationToken ct)
    {
        var command = new DownloadFileCommand(fileId);
        var response = await SendAsync<DownloadFileDto>(command, ct);

        if (response is not { } objectResult || objectResult.Value == null)
        {
            return NotFound("File not found.");
        }

        var fileDto = objectResult.Value as Response<DownloadFileDto>;

        if (fileDto?.Data == null)
        {
            return NotFound("File not found.");
        }

        return File(fileDto.Data.FileData, fileDto.Data.ContentType, fileDto.Data.FileName);
    }
}