using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetCurrencyWithDetails;

public class GetCurrencyWithDetailsQuery : IRequest<Response<CurrencyDatailDto>>
{
    public Guid Id { get; set; }
}