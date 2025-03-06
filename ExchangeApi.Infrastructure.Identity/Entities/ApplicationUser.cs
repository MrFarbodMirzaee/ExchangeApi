﻿using Microsoft.AspNetCore.Identity;

namespace ExchangeApi.Infrastructure.Identity.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}