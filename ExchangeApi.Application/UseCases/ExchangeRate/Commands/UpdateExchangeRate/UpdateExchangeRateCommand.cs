#nullable disable
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands;

public record UpdateExchangeRateCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public ExchangeApi.Domain.Entities.ExchangeRate ExchangeRate { get; set; }
}
