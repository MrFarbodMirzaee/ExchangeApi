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
        Response<List<ExchangeApi.Domain.Entities.ExchangeTransaction>> data = await _exchangeTranzacstionService.FindByCondition(x => x.Id == request.ExTId, ct);
        if (data is null)
        {
            return new Response<List<ExchangeTransactionDto>>(new List<ExchangeTransactionDto>());
        }
        var exchangeTransaction = _mapper.Map<List<ExchangeTransactionDto>>(data.Data);
        return new Response<List<ExchangeTransactionDto>>(new List<ExchangeTransactionDto>(exchangeTransaction));
    }
}
