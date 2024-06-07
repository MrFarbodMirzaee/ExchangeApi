using System.Net;
using System.ComponentModel.DataAnnotations;

namespace ExchangeApi.Domain.Entities;

public class IpAddress
{
    //The Required attribute ensures that the IP address is not null or empty.
    [Required]
    public string IPAddress { get; set; }
}
