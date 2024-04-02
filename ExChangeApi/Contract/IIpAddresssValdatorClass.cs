using ExchangeApi.Models;

namespace ExchangeApi.Contract;

public interface IIpAddresssValdatorClass
{
    bool ValidatorIpAddress(IpAddress ipAddress);
}
