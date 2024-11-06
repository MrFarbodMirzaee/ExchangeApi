namespace ExchangeApi.Application.Dtos;
public record UserDto(int Id, string Name, string UserName, string EmailAddress, string Password, bool IsActive);