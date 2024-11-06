using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries;
public class SearchCurrencyQueryHandler : IRequestHandler<SearchCurrencyQuery, Response<List<CurrencyDto>>>
{
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;
    public SearchCurrencyQueryHandler(ICurrencyService currencyService, IMapper mapper)
    {
        _currencyService = currencyService;
        _mapper = mapper;
    }
    public async Task<Response<List<CurrencyDto>>> Handle(SearchCurrencyQuery request, CancellationToken ct)
    {
        Response<List<ExChangeApi.Domain.Entities.Currency>> currency = await _currencyService.FindByCondition(x => x.CurrencyCode == request.Word, ct);
        var currencies = _mapper.Map<List<CurrencyDto>>(currency.Data);
        return currency.Succeeded ? new Response<List<CurrencyDto>>(currencies) : new Response<List<CurrencyDto>>(currency.Message);
    }
}


