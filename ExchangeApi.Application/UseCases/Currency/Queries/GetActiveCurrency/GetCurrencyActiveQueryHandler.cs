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
        Response<List<ExChangeApi.Domain.Entities.Currency>> currencyFind = await _currencyService.FindByCondition(x => x.IsActive == true, ct);

        var currencies = _mapper.Map<List<CurrencyDto>>(currencyFind.Data);
        return currencyFind.Succeeded ? new Response<List<CurrencyDto>>(currencies) : new Response<List<CurrencyDto>>(currencyFind.Message);
    }
}
