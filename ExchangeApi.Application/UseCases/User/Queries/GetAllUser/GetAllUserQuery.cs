#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.ValueObjects;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries.GetAllUser;

public class GetAllUserQuery : IRequest<Response<List<UserDto>>>
{
    public QueryCriteria QueryCriteria { get; set; }
}