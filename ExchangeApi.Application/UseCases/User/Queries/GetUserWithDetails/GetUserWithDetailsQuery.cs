using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries.GetUserWithDetails;

public record GetUserWithDetailsQuery : IRequest<Response<UserDetailDto>>
{
    public Guid Id { get; set; }
}