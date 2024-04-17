using FluentValidation;

namespace ExchangeApi.Application.Dtos;

public sealed class UserDto : AddUserDto
{
    public int Id { get; set; }

}
