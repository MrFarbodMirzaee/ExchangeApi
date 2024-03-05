using ExchangeApi.Contract;
using ExchangeApi.Dtos;
using ExChangeApi.Dtos;
using ExchangeApi.Models;
using Microsoft.AspNetCore.Mvc;
using ExChangeApi.Models;

namespace ExchangeApi.Controllers.V1;

public class UserContoller : BaseContoller
{
    private readonly IUserBusiness _userBusiness;
    public UserContoller(IUserBusiness userBusiness)
    {
        _userBusiness = userBusiness;
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
        UserDto user = new UserDto()
        {
            Id = data.Id,
            EmailAddress = data.EmailAddress,
            Name = data.Name,
            UserName = data.UserName,
        };
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
    public IActionResult AddUser([FromBody] AddUser addUser)
    {
        if (string.IsNullOrEmpty(addUser.UserName) || string.IsNullOrEmpty(addUser.EmailAddress) )
        {
            return BadRequest();
        }
        var Userdata = new User()
        {
            Id = 1,

            Created = DateTime.Now,
        };
        _userBusiness.CreateUser(Userdata);
        return Created();
    }
}
