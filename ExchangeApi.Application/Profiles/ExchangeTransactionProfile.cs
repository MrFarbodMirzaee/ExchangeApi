using AutoMapper;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Wrappers;




namespace ExchangeApi.Application.Profiles;

public class ExchangeTransactionProfile : Profile
{
    public ExchangeTransactionProfile() 
    {
        CreateMap<Response<List<ExchangeTransaction>>, List<ExchangeTransactionDto>>();
        CreateMap<Response<ExchangeTransaction>, ExchangeTransactionDto>();
        CreateMap<ExchangeTransaction, ExchangeTransactionDto>();
        CreateMap<ExchangeTransactionDto, ExchangeTransaction>();
        CreateMap<AddExchangeTransactionDto, ExchangeTransaction>();
        CreateMap<ExchangeTransaction, AddExchangeTransactionDto>();

        CreateMap<bool, ExchangeTransaction>()
          .ConvertUsing(src => src ? new ExchangeTransaction() : null);
    }
}
