using Microsoft.AspNetCore.Identity;

namespace ExchangeApi.Infrustructure.Identity.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Address Address { get; set; }
}