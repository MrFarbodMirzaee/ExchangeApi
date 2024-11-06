using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Queries;
public record GetAllCurrencyQuery : IRequest<Response<List<CurrencyDto>>> { }

