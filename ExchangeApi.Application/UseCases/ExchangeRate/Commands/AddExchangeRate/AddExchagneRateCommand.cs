#nullable disable
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Commands;

public record AddExchagneRateCommand : IRequest<Response<int>>
{
    public int FromCurrency { get; set; }
    public int ToCurrency { get; set; }
    public decimal Rate { get; set; }
    public bool IsActive { get; set; }
}
