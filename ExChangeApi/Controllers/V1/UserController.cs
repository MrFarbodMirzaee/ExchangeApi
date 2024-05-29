
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

namespace ExchangeApi.Controllers.V1;

public class UserController : BaseController
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
    public async Task<IActionResult> GetUserById([FromRoute] int id, CancellationToken ct)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        Response<List<User>> data = await _userService.FindByCondition(x => x.Id == id, ct);
        if (data == null)
            return NotFound();
        var user = _mapper.Map<UserDto>(data);
        return Ok(new Response<UserDto>(user));
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> GetActiveUsers(CancellationToken ct)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        
        Response<List<User>> data = await _userService.FindByCondition(A => A.IsActive == true ,ct);
        var UserDtos = _mapper.Map<List<UserDto>>(data);
        return Ok(new Response<List<UserDto>>(UserDtos));
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddUser([FromBody] AddUserDto addUser,CancellationToken ct)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        
        var UserData = _mapper.Map<User>(addUser);
        await _userService.AddAsync(UserData, ct);
        return Created();
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllUser(CancellationToken ct) 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        

        Response<List<User>> data = await _userService.GetAllAsync(ct);
        var UserDto = _mapper.Map<List<UserDto>>(data);
        return Ok(new Response<List<UserDto>>(UserDto));
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserByEmail(string email,CancellationToken ct) 
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        

        Response<List<User>> data = await _userService.FindByCondition(e => e.EmailAddress == email, ct);
        var UserDto = _mapper.Map<UserDto>(data);
        return Ok(new Response<UserDto>(UserDto));
    }
    [HttpDelete]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUser(int id, CancellationToken ct)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);


        var UserResponse = await _userService.FindByCondition(x => x.Id == id,ct);
        if (!UserResponse.Succeeded)
        {
            // Handle the case where the currency was not found
            return NotFound();
        }

        var user = UserResponse.Data.FirstOrDefault();

        var data = await _userService.DeleteAsync(user,ct);
        if (!data.Succeeded)
        {
            // Handle the case where the delete operation failed
            return StatusCode(500, data.Message);
        }
        var UserDto = _mapper.Map<bool>(data);
        return Ok(UserDto);
    }
    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUser(int id, User user,CancellationToken ct)
    {
        var ClientIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        var ipAddress = _mapper.Map<IpAddress>(ClientIpAddress);
        Response<bool> IsValidAddress = _ipAddresssValdatorClass.ValidatorIpAddress(ipAddress);
        

        user.Id = id;

        Response<bool> data = await _userService.UpdateAsync(user, ct);
        var UserDto = _mapper.Map<User>(data);
        return Ok(new Response<User>(UserDto));
    }
}
