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
        CreateMap<AddExchangeTransactionDto, ExchangeTransaction>();
        CreateMap<ExchangeTransaction, AddExchangeTransactionDto>();

        CreateMap<bool, ExchangeTransaction>()
          .ConvertUsing(src => src ? new ExchangeTransaction() : null);
    }
}
