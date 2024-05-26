using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Domain.Entitiess;

namespace ExchangeApi.Application.Contracts;

public interface IIpAddresssValdatorServices
{
    Response<bool> ValidatorIpAddress(IpAddress ipAddress);
}
