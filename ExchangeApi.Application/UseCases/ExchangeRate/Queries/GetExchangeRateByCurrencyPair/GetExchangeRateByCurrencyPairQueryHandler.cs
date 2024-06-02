

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
        Response<List<ExchangeApi.Domain.Entities.ExchangeRate>> data = await _exchangeRateService.FindByCondition(e => e.FromCurrency == request.FromCurrency && e.ToCurrency == request.ToCurrency, ct);
        if (data is null)
        {
            return new Response<List<ExchangeRateDto>>(new List<ExchangeRateDto>());
        }
        var exchangeRatesDto = _mapper.Map<List<ExchangeRateDto>>(data);
        return new Response<List<ExchangeRateDto>>(exchangeRatesDto);
    }
}
