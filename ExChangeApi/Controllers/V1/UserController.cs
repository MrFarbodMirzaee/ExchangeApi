
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using AutoMapper;
using ExchangeApi.Shered;
using Microsoft.Extensions.Options;
using ExchangeApi.Domain.Entitiess;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using User = ExChangeApi.Domain.Entities.User;
using ExchangeApi.Application.UseCases.User.Commands;
using Azure.Core;
using ExchangeApi.Application.UseCases.User.Queries;
using ExchangeApi.Application.UseCases.User.Commands.DeleteUser;

namespace ExchangeApi.Controllers.V1;

public class UserController : BaseController
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly MySettings _mySettings;
    public UserController(IUserService userService, IMapper mapper ,IOptionsMonitor<MySettings> settings)
    {
        _mySettings = settings.CurrentValue;
        _userService = userService;
        _mapper = mapper;
    }

    [Route("{id}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserById([FromRoute] GetUserByIdQuery request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetActiveUsers(GetActiveUserQuery request,CancellationToken ct) => await SendAsync(request, ct);
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddUser([FromBody] AddUserCommand command, CancellationToken ct) => await SendAsync(command, ct);
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllUser(GetAllUserQuery request,CancellationToken ct) => await SendAsync(request, ct);
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserByEmail(GetUserByEmailQuery request,CancellationToken ct) => await SendAsync(request, ct);
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUser(DeleteUserCommand request, CancellationToken ct) => await SendAsync(request, ct);
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUser(UpdateUserCommand request,CancellationToken ct) => await SendAsync(request, ct);
}
