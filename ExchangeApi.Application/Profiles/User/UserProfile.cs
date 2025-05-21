using AutoMapper;
using ExchangeApi.Application.Attributes;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Application.UseCases.User.Commands.AddUser;
using ExchangeApi.Domain.Wrappers;

namespace ExchangeApi.Application.Profiles.User;

[Profile]
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Response<List<Domain.Entities.User>>, List<UserDto>>();
        CreateMap<Response<Domain.Entities.User>, UserDto>();
        CreateMap<Domain.Entities.User, UserDto>();
        CreateMap<UserDto, Domain.Entities.User>();
        CreateMap<Domain.Entities.User, AddUserDto>();
        CreateMap<AddUserDto, Domain.Entities.User>();
        CreateMap<AddUserCommand, Domain.Entities.User>();
        CreateMap<UpdateUserDto, Domain.Entities.User>();
        CreateMap<Domain.Entities.User, UpdateUserDto>();
        CreateMap<Domain.Entities.User, UserDetailDto>();

        CreateMap<bool, Domain.Entities.User>()
            .ConvertUsing(src => (src ? new Domain.Entities.User() : null)!);
    }
}