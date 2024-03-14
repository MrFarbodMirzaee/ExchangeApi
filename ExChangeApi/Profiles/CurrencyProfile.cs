﻿using AutoMapper;
using ExchangeApi.Dtos;
using ExChangeApi.Models;

namespace ExchangeApi.Profiles;

public class CurrencyProfile : Profile
{
    public CurrencyProfile() 
    {
        CreateMap<CurrencyDto, Currency>();
        CreateMap<Currency, CurrencyDto>();
        CreateMap<List<Currency>, Currency>();
        CreateMap<Currency ,List <Currency>>();
        CreateMap<List<CurrencyDto>, Currency>();
        CreateMap<Currency,List<CurrencyDto>>();
        CreateMap<Currency, List<Currency>>();
        CreateMap<AddCurencyDto, Currency>();
        CreateMap<Currency, AddCurencyDto>();
        CreateMap<List<AddCurencyDto>, Currency>();
        CreateMap<List<Currency>, AddCurencyDto>();
    }
}
