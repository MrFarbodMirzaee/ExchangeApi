using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.AddExchangeTransaction;

public class AddExchangeTransactionCommandHandler(
    IExchangeTransactionServices exchangeTransactionServices,
    IValidator<AddExchangeTransactionCommand> addExchangeTransactionCommandValidator,
    IMapper mapper)
    : IRequestHandler<AddExchangeTransactionCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(AddExchangeTransactionCommand request, CancellationToken ct)
    {
        await addExchangeTransactionCommandValidator
            .ValidateAndThrowAsync(request,ct);
        
        var exchangeTransaction = mapper
            .Map<ExchangeApi.Domain.Entities.ExchangeTransaction>
                (request);
        
        var exchangeTransactionStatus = await 
            exchangeTransactionServices
                .AddAsync(exchangeTransaction, ct);
        
        return exchangeTransactionStatus.Succeeded
            ? new Response<bool>(exchangeTransactionStatus.Data)
            : new Response<bool>(exchangeTransactionStatus.Message);
    }
}