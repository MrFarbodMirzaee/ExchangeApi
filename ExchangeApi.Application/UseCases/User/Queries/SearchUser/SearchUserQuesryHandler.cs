using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries.SearchUser;

public class SearchUserQueryHandler(IUserService iUserService,
    IValidator<SearchUserQuery> searchUserQueryValidator
    , IMapper mapper)
    : IRequestHandler<SearchUserQuery, Response<List<UserDto>>>
{
    public async Task<Response<List<UserDto>>> Handle(SearchUserQuery request, CancellationToken ct)
    {
        await searchUserQueryValidator
        .ValidateAndThrowAsync(request, ct);
        
        var dynamicSearchUserAsync = await 
            iUserService
            .DynamicSearchUserAsync(request,ct);

        var users = mapper
            .Map<List<UserDto>>
            (dynamicSearchUserAsync.Data);

        return dynamicSearchUserAsync.Succeeded
            ? new Response<List<UserDto>>(users)
            : new Response<List<UserDto>>(dynamicSearchUserAsync.Message);
    }
}