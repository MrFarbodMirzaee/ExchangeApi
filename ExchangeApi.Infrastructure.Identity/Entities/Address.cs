using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.Infrastructure.Identity.Entities;

[Owned]
public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
}