using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries;

public class GetExchangeRateByIdQueryHandler : IRequestHandler<GetExchangeRateByIdQuery, Response<List<ExchangeRateDto>>>
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IMapper _mapper;
    public GetExchangeRateByIdQueryHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    {
        _exchangeRateService = exchangeRateService;
        _mapper = mapper;
    }
    public async Task<Response<List<ExchangeRateDto>>> Handle(GetExchangeRateByIdQuery request, CancellationToken ct)
    {
        Response<List<ExchangeApi.Domain.Entities.ExchangeRate>> data = await _exchangeRateService.FindByCondition(x => x.Id == request.Id, ct);
        if (data is null)
        {
            return new Response<List<ExchangeRateDto>>(new List<ExchangeRateDto>());
        }
        var exchangeRateDtos = _mapper.Map<List<ExchangeRateDto>>(data.Data);
        return new Response<List<ExchangeRateDto>>(exchangeRateDtos);
    }
}
