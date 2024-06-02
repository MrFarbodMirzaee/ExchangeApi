#nullable disable

using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands;

public record AddCurrencyCommand : IRequest<Response<int>>
{
    public string CurrencyCode { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
