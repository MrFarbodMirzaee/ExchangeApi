using AutoMapper;
using ExChangeApi.Domain.Entities;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;



namespace ExchangeApi.Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Response<List<User>>, List<UserDto>>();
        CreateMap<Response<User>, UserDto>();
        CreateMap<User,UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<User, AddUserDto>();
        CreateMap<AddUserDto, User>();

        CreateMap<bool, User>()
        .ConvertUsing(src => src ? new User() : null);
    }
}
