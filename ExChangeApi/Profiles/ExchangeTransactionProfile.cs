using AutoMapper;
using ExchangeApi.Dtos;
using ExchangeApi.Models;


namespace ExchangeApi.Profiles;

public class ExchangeTransactionProfile : Profile
{
    public ExchangeTransactionProfile() 
    {
        CreateMap<ExchangeTransaction, ExchangeTransactionDto>();
        CreateMap<ExchangeTransactionDto,ExchangeTransaction>();
    }
}
