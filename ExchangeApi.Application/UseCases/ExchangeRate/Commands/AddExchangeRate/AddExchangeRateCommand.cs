#nullable disable
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands.AddExchangeRate;

public record AddExchangeRateCommand : IRequest<Response<bool>>
{
    public Guid FromCurrency { get; set; }
    public Guid ToCurrency { get; set; }
    public decimal Rate { get; set; }
    public bool IsActive { get; set; }
}