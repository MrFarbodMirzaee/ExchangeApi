using AutoMapper;
using ExchangeApi.Dtos;
using ExchangeApi.Models;


namespace ExchangeApi.Profiles;

public class ExchangeTransactionProfile : Profile
{
    public ExchangeTransactionProfile() 
    {
        CreateMap<ExchangeTransaction, ExchangeTransactionDto>();
        CreateMap<ExchangeTransactionDto, ExchangeTransaction>();
        CreateMap<List<ExchangeTransaction>, ExchangeTransaction>();
        CreateMap<ExchangeTransaction, List<ExchangeTransaction>>();
        CreateMap<List<ExchangeTransactionDto>, ExchangeTransaction>();
        CreateMap<ExchangeTransaction, List<ExchangeTransactionDto>>();
        CreateMap<AddExchangeTransactionDto, ExchangeTransaction>();
        CreateMap<ExchangeTransaction, AddExchangeTransactionDto>();
        CreateMap<List<AddExchangeTransactionDto>, ExchangeTransaction>();
        CreateMap<List<ExchangeTransaction>, AddExchangeTransactionDto>();
    }
}
