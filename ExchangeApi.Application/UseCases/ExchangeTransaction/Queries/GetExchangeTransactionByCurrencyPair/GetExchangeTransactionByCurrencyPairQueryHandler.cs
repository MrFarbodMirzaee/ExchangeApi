using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries.GetExchangeTransactionByCurrencyPair;

public class GetExchangeTransactionByCurrencyPairQueryHandler(
    IExchangeTransactionServices exchangeTransactionServices,
    IMapper mapper)
    : IRequestHandler<GetExchangeTransactionByCurrencyPairQuery, Response<List<ExchangeTransactionDto>>>
{
    public async Task<Response<List<ExchangeTransactionDto>>> Handle(GetExchangeTransactionByCurrencyPairQuery request,
        CancellationToken ct)
    {
        Response<List<ExchangeApi.Domain.Entities.ExchangeTransaction>> exchangeTransactionFind =
            await exchangeTransactionServices.FindByCondition(
                f => f.FromCurrencyId == request.FromCurrency && f.ToCurrencyId == request.ToCurrency, ct);

        if (exchangeTransactionFind.Data is null)
            return new Response<List<ExchangeTransactionDto>>(exchangeTransactionFind.Message);

        var exchangeTransactionDtos = mapper.Map<List<ExchangeTransactionDto>>(exchangeTransactionFind.Data);

        return exchangeTransactionFind.Succeeded
            ? new Response<List<ExchangeTransactionDto>>(exchangeTransactionDtos)
            : new Response<List<ExchangeTransactionDto>>(exchangeTransactionFind.Message);
    }
}