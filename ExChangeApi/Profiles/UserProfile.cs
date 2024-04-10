using AutoMapper;
using ExchangeApi.Dtos;
using ExChangeApi.Domain.Entities;


namespace ExchangeApi.Profiles;

public class UserProfile : Profile
{
    public UserProfile() 
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<List<User>, User>();
        CreateMap<User, List<User>>();
        CreateMap<List<UserDto>, User>();
        CreateMap<User, List<UserDto>>();
        CreateMap<AddUserDto, User>();
        CreateMap<User, AddUserDto>();
        CreateMap<List<AddUserDto>, User>();
        CreateMap<List<User>, AddUserDto>();
        CreateMap<bool, User>()
        .ConvertUsing(src => src ? new User() : null);
    }
}
