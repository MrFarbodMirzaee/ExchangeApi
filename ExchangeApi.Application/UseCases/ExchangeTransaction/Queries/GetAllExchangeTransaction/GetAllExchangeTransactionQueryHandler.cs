

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
        Response<List<ExchangeApi.Domain.Entities.ExchangeTransaction>> data = await _exchangeTranzacstionService.GetAllAsync(ct);
        var ExchangeTranzactionDto = _mapper.Map<List<ExchangeTransactionDto>>(data);
        return new Response<List<ExchangeTransactionDto>>(ExchangeTranzactionDto);
    }
}
