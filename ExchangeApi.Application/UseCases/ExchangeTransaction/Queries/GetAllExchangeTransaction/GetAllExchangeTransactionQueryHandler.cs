using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries.GetAllExchangeTransaction;

public class GetAllExchangeTransactionQueryHandler(
    IExchangeTransactionServices exchangeTransactionServices,
    IMapper mapper)
    : IRequestHandler<GetAllExchangeTransactionQuery, Response<List<ExchangeTransactionDto>>>
{
    public async Task<Response<List<ExchangeTransactionDto>>> Handle(GetAllExchangeTransactionQuery request,
        CancellationToken ct)
    {
        var pageSize = request.PageSize;
        var page = request.Page;
        
        Response<List<ExchangeApi.Domain.Entities.ExchangeTransaction>> exchangeTransactions =
            await exchangeTransactionServices.GetAllAsync(ct, page, pageSize);

        var exchangeTransactionDtos = mapper.Map<List<ExchangeTransactionDto>>(exchangeTransactions.Data);

        return exchangeTransactions.Succeeded
            ? new Response<List<ExchangeTransactionDto>>(exchangeTransactionDtos)
            : new Response<List<ExchangeTransactionDto>>(exchangeTransactions.Message);
    }
}