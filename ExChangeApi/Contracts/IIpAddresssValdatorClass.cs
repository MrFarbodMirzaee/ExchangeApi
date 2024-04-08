using ExchangeApi.Models;
namespace ExchangeApi.Contracts;

public interface IIpAddresssValdatorClass
{
    bool ValidatorIpAddress(IpAddress ipAddress);
}
