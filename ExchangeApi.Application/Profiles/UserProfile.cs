using AutoMapper;
using ExChangeApi.Domain.Entities;
using ExchangeApi.Application.Dtos;



namespace ExchangeApi.Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile() 
    {
        CreateMap<User,UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<User, AddUserDto>();
        CreateMap<AddUserDto, User>();

        CreateMap<bool, User>()
        .ConvertUsing(src => src ? new User() : null);
    }
}
