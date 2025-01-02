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
            var pageSize = request.PageSize;
            var page = request.Page;
            Response<List<ExChangeApi.Domain.Entities.Currency>> currency = await _currencyService.GetAllAsync(ct, page, pageSize);
            var currencyMapped = _mapper.Map<List<CurrencyDto>>(currency.Data);
            return currency.Succeeded ? new Response<List<CurrencyDto>>(currencyMapped) : new Response<List<CurrencyDto>>(currency.Message);
        }
    }
}
