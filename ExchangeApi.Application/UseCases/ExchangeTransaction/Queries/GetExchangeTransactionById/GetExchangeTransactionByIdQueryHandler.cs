﻿using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries;

public class GetExchangeTransactionByIdQueryHandler : IRequestHandler<GetExchangeTransactionByIdQuery, Response<List<ExchangeTransactionDto>>>
{
    private readonly IExchangeTransactionServices _exchangeTranzacstionService;
    private readonly IMapper _mapper;
    public GetExchangeTransactionByIdQueryHandler(IExchangeTransactionServices exchangeTranzacstionService, IMapper mapper)
    {
        _exchangeTranzacstionService = exchangeTranzacstionService;
        _mapper = mapper;
    }
    public async Task<Response<List<ExchangeTransactionDto>>> Handle(GetExchangeTransactionByIdQuery request, CancellationToken ct)
    {
        Response<List<ExchangeApi.Domain.Entities.ExchangeTransaction>> exchangeTransactions = await _exchangeTranzacstionService.FindByCondition(x => x.Id == request.ExchangeTransactionId, ct);

        var exchangeTransactionMapped = _mapper.Map<List<ExchangeTransactionDto>>(exchangeTransactions.Data);

        return exchangeTransactions.Succeeded ? new Response<List<ExchangeTransactionDto>>(exchangeTransactionMapped) : new Response<List<ExchangeTransactionDto>>(exchangeTransactions.Message);
    }
}
