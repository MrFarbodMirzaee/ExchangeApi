using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Wrappers;

namespace ExchangeApi.Application.Contracts;

public interface ICurrencyAttributeService
{
    Task<Response<bool>> CreateCurrencyAttribute(CurrencyAttribute currencyAttribute);
}
