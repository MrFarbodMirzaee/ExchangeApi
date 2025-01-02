#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate;
public record GetAllExchangeRateQuery : IRequest<Response<List<ExchangeRateDto>>> 
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}
