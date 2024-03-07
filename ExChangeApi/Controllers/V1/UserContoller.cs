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
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var data = _userBusiness.GetUserById(id);
        if (data == null)
        {
            return NotFound();
        }
        var user = _mapper.Map<UserDto>(data);
        return Ok(user);
    }
    [HttpGet]
    public User GetUser()
    {
        return new User()
        {
            Id = 1,
            Name = "Farbod",
            EmailAddress = "Farbod@gmail.com",
            UserName = "Farbod",
            IsActive = true,
            Created = DateTime.Now
        };
    }
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddUser([FromBody] AddUserDto addUser)
    {
        if (string.IsNullOrEmpty(addUser.UserName) || string.IsNullOrEmpty(addUser.EmailAddress) )
        {
            return BadRequest();
        }
        var UserData = _mapper.Map<User>(addUser);
        _userBusiness.CreateUser(UserData);
        return Created();
    }
}
