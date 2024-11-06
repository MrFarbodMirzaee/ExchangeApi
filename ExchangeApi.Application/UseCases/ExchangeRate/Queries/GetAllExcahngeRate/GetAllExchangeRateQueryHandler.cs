using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries;
public class GetAllExchangeRateQueryHandler : IRequestHandler<GetAllExchangeRateQuery, Response<List<ExchangeRateDto>>>
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IMapper _mapper;
    public GetAllExchangeRateQueryHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    {
        _exchangeRateService = exchangeRateService;
        _mapper = mapper;
    }
    public async Task<Response<List<ExchangeRateDto>>> Handle(GetAllExchangeRateQuery request, CancellationToken ct)
    {
        Response<List<ExchangeApi.Domain.Entities.ExchangeRate>> exchangeRate = await _exchangeRateService.GetAllAsync(ct);
        var exchangeRateMapped = _mapper.Map<List<ExchangeRateDto>>(exchangeRate.Data);
        return exchangeRate.Succeeded ? new Response<List<ExchangeRateDto>>(exchangeRateMapped) : new Response<List<ExchangeRateDto>>(exchangeRate.Message);
    }
}

