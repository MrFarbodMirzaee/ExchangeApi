#nullable disable
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Commands;
public record AddUserCommand : IRequest<Response<bool>>
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
}
