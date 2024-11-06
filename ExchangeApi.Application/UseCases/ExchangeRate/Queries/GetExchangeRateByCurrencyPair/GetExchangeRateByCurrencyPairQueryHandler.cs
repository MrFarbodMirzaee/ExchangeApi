using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries;
public class GetExchangeRateByCurrencyPairQueryHandler : IRequestHandler<GetExchangeRateByCurrencyPairQuery, Response<List<ExchangeRateDto>>>
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IMapper _mapper;
    public GetExchangeRateByCurrencyPairQueryHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    {
        _exchangeRateService = exchangeRateService;
        _mapper = mapper;
    }
    public async Task<Response<List<ExchangeRateDto>>> Handle(GetExchangeRateByCurrencyPairQuery request, CancellationToken ct)
    {
        Response<List<ExchangeApi.Domain.Entities.ExchangeRate>> exchangeRate = await _exchangeRateService.FindByCondition(e => e.FromCurrency == request.FromCurrency && e.ToCurrency == request.ToCurrency, ct);
        
        var exchangeRatesMapped = _mapper.Map<List<ExchangeRateDto>>(exchangeRate.Data);
        return exchangeRate.Succeeded ? new Response<List<ExchangeRateDto>>(exchangeRatesMapped) : new Response<List<ExchangeRateDto>>(exchangeRate.Message);
    }
}
