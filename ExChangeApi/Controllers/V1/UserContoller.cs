using ExchangeApi.Contract;
using ExchangeApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using ExChangeApi.Models;
using System.Net.Mime;
using AutoMapper;
using ExchangeApi.Shered;
using Microsoft.Extensions.Options;
using ExchangeApi.Models;

namespace ExchangeApi.Controllers.V1;

public class UserContoller : BaseContoller
{
    private readonly IUserBusiness _userBusiness;
    private readonly IMapper _mapper;
    private readonly MySettings _mySettings;
    public UserContoller(IUserBusiness userBusiness,IMapper mapper ,IOptionsMonitor<MySettings> settings)
    {
        _mySettings = settings.CurrentValue;
        _userBusiness = userBusiness;
        _mapper = mapper;
    }

    [Route("{id}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserById([FromRoute] int id)
    {
        var data = _userBusiness.GetUserById(id);
        var user = _mapper.Map<UserDto>(data);
        return Ok(user);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> GetActiveUsers()
    {
        var data = _userBusiness.GetActiveUsers();
        var UserDtos = _mapper.Map<List<UserDto>>(data);
        return Ok(UserDtos);
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddUser([FromBody] AddUserDto addUser)
    {
        
        var UserData = _mapper.Map<User>(addUser);
        _userBusiness.CreateUser(UserData);
        return Created();
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllUser() 
    {
        var data = _userBusiness.GetAllUsers();
        var UserDto = _mapper.Map<List<UserDto>>(data);
        return Ok(UserDto);
    }
    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserByEmail(string email) 
    {
        var data = _userBusiness.GetUserByEmail(email);
        var UserDto = _mapper.Map<UserDto>(data);
        return Ok(UserDto);
    }
}
