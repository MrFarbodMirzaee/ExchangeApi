using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.AddAttributes;

public record AddAttributeCommand : IRequest<Response<bool>>
{
    public Guid CurrencyId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}