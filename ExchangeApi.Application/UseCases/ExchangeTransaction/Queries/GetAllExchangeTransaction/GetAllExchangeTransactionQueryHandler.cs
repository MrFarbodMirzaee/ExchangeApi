using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries;
public class GetAllExchangeTransactionQueryHandler : IRequestHandler<GetAllExchangeTransactionQuery, Response<List<ExchangeTransactionDto>>>
{
    private readonly IExchangeTransactionServices _exchangeTranzacstionService;
    private readonly IMapper _mapper;
    public GetAllExchangeTransactionQueryHandler(IExchangeTransactionServices exchangeTranzacstionService, IMapper mapper)
    {
        _exchangeTranzacstionService = exchangeTranzacstionService;
        _mapper = mapper;
    }
    public async Task<Response<List<ExchangeTransactionDto>>> Handle(GetAllExchangeTransactionQuery request, CancellationToken ct)
    {
        Response<List<ExchangeApi.Domain.Entities.ExchangeTransaction>> exchangeTransactions = await _exchangeTranzacstionService.GetAllAsync(ct);

        var ExchangeTranzactionMapped = _mapper.Map<List<ExchangeTransactionDto>>(exchangeTransactions.Data);

        return exchangeTransactions.Succeeded ? new Response<List<ExchangeTransactionDto>>(ExchangeTranzactionMapped) : new Response<List<ExchangeTransactionDto>>(exchangeTransactions.Message);
    }
}
