using ExchangeApi.Domain.Entitiess;

namespace ExchangeApi.Application.Contracts;

public interface IIpAddresssValdatorServices
{
    bool ValidatorIpAddress(IpAddress ipAddress);
}
