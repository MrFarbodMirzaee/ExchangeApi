using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApi.Infrustructure.Identity.Entities;

public class ApplicationUser : IdentityUser
{
    public int FirstName { get; set; }
    public int LastName { get; set; }
    public List<RefreshToken> RefreshTokens { get; set; }
    public bool OwnsToken(string token) 
    {
        return this.RefreshTokens?.Find(x=>x.Token == token) != null;
    }
}
