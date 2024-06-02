using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetActiveCurrency;

public class GetCurrencyActiveQueryHandler : IRequestHandler<GetCurrencyActiveQuery, Response<List<CurrencyDto>>>
{
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;
    public GetCurrencyActiveQueryHandler(ICurrencyService currencyService, IMapper mapper)
    {
        _currencyService = currencyService;
        _mapper = mapper;
    }

    public async Task<Response<List<CurrencyDto>>> Handle(GetCurrencyActiveQuery request, CancellationToken ct)
    {
        Response<List<ExChangeApi.Domain.Entities.Currency>> data = await _currencyService.FindByCondition(x => x.IsActive == true, ct);
        if (data is null)
        {
            return new Response<List<CurrencyDto>>(new List<CurrencyDto>());
        }
        var currencies = _mapper.Map<List<CurrencyDto>>(data);
        return new Response<List<CurrencyDto>>(currencies);
    }
}
