
namespace ExchangeApi.Application.Dtos;

public record UserDto 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
}
