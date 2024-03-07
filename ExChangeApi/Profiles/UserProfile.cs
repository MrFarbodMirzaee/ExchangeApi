using AutoMapper;
using ExchangeApi.Dtos;
using ExchangeApi.Models;


namespace ExchangeApi.Profiles;

public class UserProfile : Profile
{
    public UserProfile() 
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
    }
}
