using ExchangeApi.Domain.Entities;
using ExchangeApi.Domain.Wrappers;


namespace ExchangeApi.Application.Contracts;

public interface IIpAddresssValdatorServices
{
    Response<bool> ValidatorIpAddress(IpAddress ipAddress);
}
