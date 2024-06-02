#nullable disable

using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands;

public record DeleteExchangeRateCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
}
