using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries;
public class GetLatestExchangeRateQueryHandler : IRequestHandler<GetLatestExchangeRateQuery, Response<List<ExchangeRateDto>>>
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IMapper _mapper;
    public GetLatestExchangeRateQueryHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    {
        _exchangeRateService = exchangeRateService;
        _mapper = mapper;
    }
    public async Task<Response<List<ExchangeRateDto>>> Handle(GetLatestExchangeRateQuery request, CancellationToken ct)
    {
        Response<List<ExchangeApi.Domain.Entities.ExchangeRate>> exchangeRate = await _exchangeRateService.FindByCondition(e => e.FromCurrency == request.FromCurrency && e.ToCurrency == request.ToCurrency, ct);
        if (exchangeRate.Data is null)
            return new Response<List<ExchangeRateDto>>(exchangeRate.Message);

        var orderByDesc = exchangeRate.Data.OrderByDescending(e => e.Created);
        
        var exchangeRateMapped = _mapper.Map<List<ExchangeRateDto>>(orderByDesc);
        return exchangeRate.Succeeded ? new Response<List<ExchangeRateDto>>(exchangeRateMapped) : new Response<List<ExchangeRateDto>>(exchangeRate.Message);
    }
}
