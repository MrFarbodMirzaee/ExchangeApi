using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries.SearchUser;

public record SearchUserQuery : IRequest<Response<List<UserDto>>>
{
    /// <summary>
    /// The full name of the user.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// A unique username chosen by the user for login.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// The user's email address for communication and notifications.
    /// </summary>
    public string? EmailAddress { get; set; }

}