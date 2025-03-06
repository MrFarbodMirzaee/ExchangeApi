using AutoMapper;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.AddExchangeTransaction;
using ExchangeApi.Domain.Wrappers;

namespace ExchangeApi.Application.Profiles.ExchangeTransaction;

public class ExchangeTransactionProfile : Profile
{
    public ExchangeTransactionProfile()
    {
        CreateMap<Response<List<Domain.Entities.ExchangeTransaction>>, List<ExchangeTransactionDto>>();
        CreateMap<Response<Domain.Entities.ExchangeTransaction>, ExchangeTransactionDto>();
        CreateMap<Domain.Entities.ExchangeTransaction, ExchangeTransactionDto>();
        CreateMap<ExchangeTransactionDto, Domain.Entities.ExchangeTransaction>();
        CreateMap<AddExchangeTransactionDto, Domain.Entities.ExchangeTransaction>();
        CreateMap<Domain.Entities.ExchangeTransaction, AddExchangeTransactionDto>();
        CreateMap<AddExchangeTransactionCommand, Domain.Entities.ExchangeTransaction>();
        CreateMap<AddExchangeTransactionCommand, ExchangeTransactionDto>();
        CreateMap<UpdateExchangeTransactionDto, Domain.Entities.ExchangeTransaction>();
        CreateMap<Domain.Entities.ExchangeTransaction, UpdateExchangeTransactionDto>();

        CreateMap<bool, Domain.Entities.ExchangeTransaction>()
            .ConvertUsing(src => (src ? new Domain.Entities.ExchangeTransaction() : null)!);
    }
}