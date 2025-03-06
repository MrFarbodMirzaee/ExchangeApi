namespace ExchangeApi.Application.Dtos;

public record UserDto(
    Guid Id,
    string Name,
    string UserName,
    string EmailAddress,
    string Password,
    bool IsActive
);