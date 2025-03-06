using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.UpdateExchangeTransaction;

public class UpdateExchangeTransactionCommandHandler(
    IExchangeTransactionServices exchangeTransactionServices,
    IMapper mapper)
    : IRequestHandler<UpdateExchangeTransactionCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(UpdateExchangeTransactionCommand request, CancellationToken ct)
    {
        var exchangeTransactionEntity = mapper.Map<Domain.Entities.ExchangeTransaction>(request.UpdateExchangeTransactionDto);
       
        exchangeTransactionEntity.Id = request.Id;
        exchangeTransactionEntity.Updated = DateTime.Now;

        Response<bool> exchangeTransactionStatus =
            await exchangeTransactionServices.UpdateAsync(exchangeTransactionEntity, ct);

        return exchangeTransactionStatus.Succeeded
            ? new Response<bool>(exchangeTransactionStatus.Data)
            : new Response<bool>(exchangeTransactionStatus.Message);
    }
}