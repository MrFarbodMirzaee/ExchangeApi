using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetCurrencyWithDetails;

public class GetCurrencyWithDetailsQueryHandler(ICurrencyService service,IMapper mapper) 
    : IRequestHandler<GetCurrencyWithDetailsQuery,Response<CurrencyDatailDto>>
{
    public async Task<Response<CurrencyDatailDto>> Handle(GetCurrencyWithDetailsQuery request, CancellationToken ct)
    {
        var currencyDetailsAsync = await service.GetCurrencyDetailsAsync(request,ct);
        
        return currencyDetailsAsync.Succeeded
            ? new Response<CurrencyDatailDto>(currencyDetailsAsync.Data)
            : new Response<CurrencyDatailDto>(currencyDetailsAsync.Message);
    }
}