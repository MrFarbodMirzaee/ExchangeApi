

using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetAllCurrency
{
    public class GetAllCurrencyQueryHandler : IRequestHandler<GetAllCurrencyQuery, Response<List<CurrencyDto>>>
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMapper _mapper;
        public GetAllCurrencyQueryHandler(ICurrencyService currencyService, IMapper mapper)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }
        public async Task<Response<List<CurrencyDto>>> Handle(GetAllCurrencyQuery request, CancellationToken ct)
        {

            Response<List<ExChangeApi.Domain.Entities.Currency>> data = await _currencyService.GetAllAsync(ct);
            var currencyDto = _mapper.Map<List<CurrencyDto>>(data.Data);
            return new Response<List<CurrencyDto>>(currencyDto);
        }
    }
}
