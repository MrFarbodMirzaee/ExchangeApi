#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries;
public record GetExchangeRateByIdQuery : IRequest<Response<List<ExchangeRateDto>>>
{
    public int Id { get; set; }
}
