using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.AddExchangeTransaction;

public class AddExchangeTransactionCommandHandler(
    IExchangeTransactionServices exchangeTransactionServices,
    IMapper mapper)
    : IRequestHandler<AddExchangeTransactionCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(AddExchangeTransactionCommand request, CancellationToken ct)
    {
        var exchangeTransaction = mapper.Map<ExchangeApi.Domain.Entities.ExchangeTransaction>(request);
        
        var exchangeTransactionStatus = await exchangeTransactionServices.AddAsync(exchangeTransaction, ct);
        
        return exchangeTransactionStatus.Succeeded
            ? new Response<bool>(exchangeTransactionStatus.Data)
            : new Response<bool>(exchangeTransactionStatus.Message);
    }
}