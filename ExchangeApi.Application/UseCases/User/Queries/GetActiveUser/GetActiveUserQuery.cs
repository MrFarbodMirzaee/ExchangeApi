#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries.GetActiveUser;

public record GetActiveUserQuery : IRequest<Response<List<UserDto>>>
{
}