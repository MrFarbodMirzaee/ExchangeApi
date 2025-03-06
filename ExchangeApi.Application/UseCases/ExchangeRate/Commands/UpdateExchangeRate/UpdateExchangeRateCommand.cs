#nullable disable
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands.UpdateExchangeRate;

public record UpdateExchangeRateCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public UpdateExchangeRateDto UpdateExchangeRateDto { get; set; }
}