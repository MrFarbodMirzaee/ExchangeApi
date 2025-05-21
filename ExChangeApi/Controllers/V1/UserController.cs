using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using ExchangeApi.Shared;
using Microsoft.Extensions.Options;
using ExchangeApi.Application.UseCases.User.Commands.AddUser;
using ExchangeApi.Application.UseCases.User.Commands.DeleteUser;
using ExchangeApi.Application.UseCases.User.Commands.UpdateUser;
using ExchangeApi.Application.UseCases.User.Queries.GetActiveUser;
using ExchangeApi.Application.UseCases.User.Queries.GetAllUser;
using ExchangeApi.Application.UseCases.User.Queries.GetAllUserByPdf;
using ExchangeApi.Application.UseCases.User.Queries.GetAllUserInExcelFormatQuery;
using ExchangeApi.Application.UseCases.User.Queries.GetUserByEmail;
using ExchangeApi.Application.UseCases.User.Queries.GetUserById;
using ExchangeApi.Application.UseCases.User.Queries.GetUserWithDetails;
using ExchangeApi.Application.UseCases.User.Queries.SearchUser;
using ExchangeApi.Application.UseCases.User.UploadByExcleFile;
using Microsoft.AspNetCore.Authorization;

namespace ExchangeApi.Controllers.V1;

public class UserController(IOptionsMonitor<MySettings> settings) : BaseController
{
    private readonly MySettings
        _settings = settings
            .CurrentValue; // I write this just because of showing OptionBuilder Pattern, but it is useless in my project

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll([FromBody] GetAllUserQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllByPdf([FromQuery] GetAllUserByPdfQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromQuery] GetUserByIdQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllInExcleFormat([FromQuery] GetAllUserInExcelFormatQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetActive([FromQuery] GetActiveUserQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByEmail([FromQuery] GetUserByEmailQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);
    
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SearchUser([FromQuery] SearchUserQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);
    
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserWithDetails([FromQuery] GetUserWithDetailsQuery request, CancellationToken ct) =>
        await SendAsync(request, ct);

    [Authorize]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddUserCommand command, CancellationToken ct) =>
        await SendAsync(command, ct);
    
    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddByExcel([FromForm] UserUploadByExcleCommand command, CancellationToken ct) =>
        await SendAsync(command, ct);

    [Authorize]
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(UpdateUserCommand request, CancellationToken ct) =>
        await SendAsync(request, ct);

    [Authorize]
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(DeleteUserCommand request, CancellationToken ct) =>
        await SendAsync(request, ct);
}