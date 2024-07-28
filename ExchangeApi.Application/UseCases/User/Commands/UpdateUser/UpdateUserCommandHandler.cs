using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.User.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<int>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    public async Task<Response<int>> Handle(UpdateUserCommand request, CancellationToken ct)
    {
        request.User.Id = request.Id;
        request.User.Updated = DateTime.Now;
        Response<bool> data = await _userService.UpdateAsync(request.User, ct);
        var UserDto = _mapper.Map<ExChangeApi.Domain.Entities.User>(data.Data);
        return new Response<int>(1);
    }
}
