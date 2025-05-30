using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.DeleteExchangeTransaction;

public class DeleteExchangeTransactionCommandHandler(
    IExchangeTransactionServices exchangeTransactionServices,
    IValidator<DeleteExchangeTransactionCommand> deleteExchangeTransactionCommandValidator,
    IMapper mapper)
    : IRequestHandler<DeleteExchangeTransactionCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(DeleteExchangeTransactionCommand request, CancellationToken ct)
    {
        await deleteExchangeTransactionCommandValidator
        .ValidateAndThrowAsync(request,ct);
        
        var exchangeTransactionsFind = await
            exchangeTransactionServices
            .FindByCondition(x => x.Id == request.Id, ct);

        if (!exchangeTransactionsFind.Succeeded)
            return new Response<bool>(exchangeTransactionsFind.Message);

        var exchangeTransaction = exchangeTransactionsFind.Data.FirstOrDefault();

        var exchangeTransactionsStatus = await exchangeTransactionServices.DeleteAsync(exchangeTransaction!, ct);

        var exchangeTransactionDto = mapper.Map<bool>(exchangeTransactionsStatus.Data);

        return exchangeTransactionsStatus.Succeeded
            ? new Response<bool>(exchangeTransactionDto)
            : new Response<bool>(exchangeTransactionsStatus.Message);
    }
}