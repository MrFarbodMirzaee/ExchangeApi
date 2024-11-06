#nullable disable
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Commands.DeleteUser;
public record DeleteUserCommand : IRequest<Response<bool>>
{
    public int Id { get; set; }
}
