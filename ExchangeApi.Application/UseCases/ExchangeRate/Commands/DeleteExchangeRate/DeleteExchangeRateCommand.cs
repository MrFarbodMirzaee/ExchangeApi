#nullable disable
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands.DeleteExchangeRate;

public record DeleteExchangeRateCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}