#nullable disable

using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries;

public record GetUserByEmailQuery : IRequest<Response<UserDto>>
{
    public string Email { get; set; }
}
