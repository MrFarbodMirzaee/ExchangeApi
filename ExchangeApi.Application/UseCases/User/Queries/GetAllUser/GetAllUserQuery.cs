#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries.GetAllUser;

public class GetAllUserQuery : IRequest<Response<List<UserDto>>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}