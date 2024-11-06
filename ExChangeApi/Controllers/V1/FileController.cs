using ExchangeApi.Application.Dtos;
using ExchangeApi.Application.UseCases.File;
using ExchangeApi.Application.UseCases.File.Download;
using ExchangeApi.Domain.Wrappers;
using IdentityModel.OidcClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using System.Threading;

namespace ExchangeApi.Controllers.V1;
public class FileController : BaseController
{
    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Upload(UploadFileCommand command, CancellationToken ct) => await SendAsync(command, ct);
    [Authorize]
    [HttpGet("download")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Download([FromQuery] int fileId, CancellationToken ct)
    {
        var command = new DownloadFileCommand(fileId);
        var response = await SendAsync<DownloadFileDto>(command, ct); // Specify DownloadFileDto here


        // Check if response is not null and contains a valid file data
        if (response is not ObjectResult objectResult || objectResult.Value == null)
        {
            return NotFound("File not found.");
        }

        var fileDto = objectResult.Value as Response<DownloadFileDto>;

        if (fileDto?.Data == null)
        {
            return NotFound("File not found.");
        }

        // Return the file as an attachment using the File() method
        return File(fileDto.Data.FileData, fileDto.Data.ContentType, fileDto.Data.FileName);
    }
}
