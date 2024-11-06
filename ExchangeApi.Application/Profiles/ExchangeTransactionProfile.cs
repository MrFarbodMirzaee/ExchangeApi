using AutoMapper;
using ExchangeApi.Domain.Entities;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.AddExchangeTransaction;

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
        CreateMap<AddExchangeTransactionCommand, ExchangeTransaction>();
        CreateMap<AddExchangeTransactionCommand, ExchangeTransactionDto>();

        CreateMap<bool, ExchangeTransaction>()
          .ConvertUsing(src => src ? new ExchangeTransaction() : null);
    }
}
