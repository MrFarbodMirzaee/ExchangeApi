
using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries;

public class GetExchangeTransactionByCurrencyPairQueryHandler : IRequestHandler<GetExchangeTransactionByCurrencyPairQuery, Response<ExchangeTransactionDto>>
{
    private readonly IExchangeTransactionServices _exchangeTranzacstionService;
    private readonly IMapper _mapper;
    public GetExchangeTransactionByCurrencyPairQueryHandler(IExchangeTransactionServices exchangeTranzacstionService, IMapper mapper)
    {
        _exchangeTranzacstionService = exchangeTranzacstionService;
        _mapper = mapper;
    }
    public async Task<Response<ExchangeTransactionDto>> Handle(GetExchangeTransactionByCurrencyPairQuery request, CancellationToken ct)
    {
        Response<List<ExchangeApi.Domain.Entitiess.ExchangeTransaction>> data = await _exchangeTranzacstionService.FindByCondition(f => f.FromCurrencyId == request.FromCurrency && f.ToCurrencyId == request.ToCurrency, ct);
        if (data is null)
        {
            return new Response<ExchangeTransactionDto>( new ExchangeTransactionDto());
        }
        var exchangeTranzacstionDto = _mapper.Map<ExchangeTransactionDto>(data);
        return new Response<ExchangeTransactionDto>(exchangeTranzacstionDto);
    }
}
