using ExchangeApi.Domain.Entities;

namespace ExchangeApi.Application.Contracts;

public interface ICurrencyAttributeService
{
    Task<bool> CreateCurrencyAttribute(CurrencyAttribute currencyAttribute);
}
