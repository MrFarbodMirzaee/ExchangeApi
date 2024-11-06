using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute;
public record AddAttributeCommand : IRequest<Response<bool>>
{
    public int CurrencyId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}
