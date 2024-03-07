using ExchangeApi.Dtos;
using FluentValidation;

namespace ExchangeApi.Dtos;

public sealed class UserDto : AddUserDto
{
    public int Id { get; set; }

}
