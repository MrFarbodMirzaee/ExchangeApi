using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;


namespace ExchangeApi.Application.UseCases.Currency.Queries;

public class SearchCurrencyQuery : IRequest<Response<List<CurrencyDto>>>
{
    public string Word { get; set; }
}


