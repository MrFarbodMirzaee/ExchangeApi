#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Commands.UpdateUser;

public record UpdateUserCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public UpdateUserDto UpdateUserDto { get; set; }
}