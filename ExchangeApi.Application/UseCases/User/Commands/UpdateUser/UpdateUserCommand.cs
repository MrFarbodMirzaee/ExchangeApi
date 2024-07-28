#nullable disable
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Commands;

public record UpdateUserCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public ExChangeApi.Domain.Entities.User User { get; set; }
}
