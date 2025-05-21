using AutoMapper;
using ExchangeApi.Application.Attributes;
using ExchangeApi.Application.Dtos;

namespace ExchangeApi.Application.Profiles.Category;

[Profile]
public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Domain.Entities.Category, CategoryDto>();
        CreateMap<CategoryDto, Domain.Entities.Category>();
    }
}