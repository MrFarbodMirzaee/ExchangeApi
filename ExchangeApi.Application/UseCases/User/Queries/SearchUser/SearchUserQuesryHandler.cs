using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries.SearchUser;

public class SearchUserQueryHandler(IUserService iUserService, IMapper mapper)
    : IRequestHandler<SearchUserQuery, Response<List<UserDto>>>
{
    public async Task<Response<List<UserDto>>> Handle(SearchUserQuery request, CancellationToken ct)
    {
        var dynamicSearchUserAsync = await iUserService.DynamicSearchUserAsync(request,ct);

        var users = mapper.Map<List<UserDto>>(dynamicSearchUserAsync.Data);

        return dynamicSearchUserAsync.Succeeded
            ? new Response<List<UserDto>>(users)
            : new Response<List<UserDto>>(dynamicSearchUserAsync.Message);
    }
}