#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries.GetUserById;

public record GetUserByIdQuery : IRequest<Response<List<UserDto>>>
{
    public Guid UserId { get; set; }
}