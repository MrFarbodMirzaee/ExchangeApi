using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetCurrencyWithDetails;

public class GetCurrencyWithDetailsQueryHandler(ICurrencyService service,
    IValidator<GetCurrencyWithDetailsQuery> getCurrencyWithDetailsQueryValidator,
    IMapper mapper) 
    : IRequestHandler<GetCurrencyWithDetailsQuery,Response<CurrencyDetailDto>>
{
    public async Task<Response<CurrencyDetailDto>> Handle(GetCurrencyWithDetailsQuery request, CancellationToken ct)
    {
        await getCurrencyWithDetailsQueryValidator
        .ValidateAndThrowAsync(request,ct);
        
        var currencyDetailsAsync = await 
            service
            .GetCurrencyDetailsAsync(request,ct);
        
        return currencyDetailsAsync.Succeeded
            ? new Response<CurrencyDetailDto>(currencyDetailsAsync.Data)
            : new Response<CurrencyDetailDto>(currencyDetailsAsync.Message);
    }
}