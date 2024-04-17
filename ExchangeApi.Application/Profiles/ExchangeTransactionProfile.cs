using AutoMapper;
using ExchangeApi.Domain.Entitiess;
using ExchangeApi.Application.Dtos;



namespace ExchangeApi.Application.Profiles;

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
        CreateMap<bool, ExchangeTransaction>()
          .ConvertUsing(src => src ? new ExchangeTransaction() : null);
    }
}
