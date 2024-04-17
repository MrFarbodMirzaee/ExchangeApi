
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using AutoMapper;
using ExchangeApi.Shered;
using Microsoft.Extensions.Options;
using ExchangeApi.Domain.Entitiess;
using ExChangeApi.Domain.Entities;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;

namespace ExchangeApi.Controllers.V1;

public class UserController : BaseContoller
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly MySettings _mySettings;
    private readonly IIpAddresssValdatorServices _ipAddresssValdatorClass;
    public UserController(IUserService userService, IMapper mapper ,IOptionsMonitor<MySettings> settings,IIpAddresssValdatorServices ipAddresssValdatorClass)
    {
        _mySettings = settings.CurrentValue;
        _userService = userService;
        _mapper = mapper;
        _ipAddresssValdatorClass = ipAddresssValdatorClass;
    }

    [Route("{id}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserById([FromRoute] int id)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = _userService.GetUserById(id);
        var user = _mapper.Map<UserDto>(data);
        return Ok(user);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> GetActiveUsers()
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = _userService.GetActiveUsers();
        var UserDtos = _mapper.Map<List<UserDto>>(data);
        return Ok(UserDtos);
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddUser([FromBody] AddUserDto addUser)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var UserData = _mapper.Map<User>(addUser);
        _userService.CreateUser(UserData);
        return Created();
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllUser() 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = _userService.GetAllUsers();
        var UserDto = _mapper.Map<List<UserDto>>(data);
        return Ok(UserDto);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserByEmail(string email) 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = _userService.GetUserByEmail(email);
        var UserDto = _mapper.Map<UserDto>(data);
        return Ok(UserDto);
    }
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        var data = _userService.DeleteUser(id);
        var UserDto = _mapper.Map<bool>(data);
        return Ok(UserDto);
    }
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        bool IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        if (!IsValidAddress)
        {
            return BadRequest();
        }

        user.Id = id;

        var data = _userService.UpdateUser(user);
        var UserDto = _mapper.Map<User>(data);
        return Ok(UserDto);
    }
}
