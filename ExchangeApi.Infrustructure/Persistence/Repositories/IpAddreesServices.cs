using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Entitiess;


namespace ExchangeApi.Infrustructure.Repository;

public class IpAddreesServices : IIpAddresssValdatorServices
{
    public bool ValidatorIpAddress(IpAddress ipAddress)
    {
        // Check if the IP address is not null or empty
        if (string.IsNullOrEmpty(ipAddress.IPAddress))
        {
            return false;
        }
        // Validate IP address format for public IPv4 addresses
        if (System.Net.IPAddress.TryParse(ipAddress.IPAddress, out System.Net.IPAddress ip))
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) // IPv4
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(ipAddress.IPAddress, @"\b(?:\d{1,3}\.){3}\d{1,3}\b"))
                {
                    return false;
                }
            }
            else if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) // IPv6
            {

            }
        }
        else if (ipAddress.IPAddress == "127.0.0.1" || ipAddress.IPAddress == "::1")
        {
            // Allow local IP addresses (loopback addresses)
            return true;
        }

        return true; // Valid IP address
    }
}
