

using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetCurrencyById;

public class GetCurrencyByIdQueryHandler : IRequestHandler<GetCurrencyByIdQuery, Response<List<CurrencyDto>>>
{
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;
    public GetCurrencyByIdQueryHandler(ICurrencyService currencyService, IMapper mapper)
    {
        _currencyService = currencyService;
        _mapper = mapper;
    }
    public async Task<Response<List<CurrencyDto>>> Handle(GetCurrencyByIdQuery request, CancellationToken ct)
    {
        Response<List<ExChangeApi.Domain.Entities.Currency>> data = await _currencyService.FindByCondition(x => x.Id == request.CurrencyId, ct);
        if (data is null)
        {
            return new Response<List<CurrencyDto>>(new List<CurrencyDto>());
        }
        var currencyDto = _mapper.Map<CurrencyDto>(data);
        return new Response<List<CurrencyDto>>(new List<CurrencyDto> { currencyDto });
    }
}
