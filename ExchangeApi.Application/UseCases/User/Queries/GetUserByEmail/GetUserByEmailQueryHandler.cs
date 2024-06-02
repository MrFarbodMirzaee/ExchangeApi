﻿

using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Queries;

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, Response<UserDto>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public GetUserByEmailQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    public async Task<Response<UserDto>> Handle(GetUserByEmailQuery request, CancellationToken ct)
    {

        Response<List<ExChangeApi.Domain.Entities.User>> data = await _userService.FindByCondition(e => e.EmailAddress == request.Email, ct);

        var UserDto = _mapper.Map<UserDto>(data);
        return new Response<UserDto>(UserDto);
    }
}

