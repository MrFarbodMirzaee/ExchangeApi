using ExchangeApi.Domain.Contracts;
using ExChangeApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApi.Infrustructure.Persistence.Seeder;

public class UserSeeder : IBaseSeeder<User>
{
    public IEnumerable<User> GetSeedData()
    {
        throw new NotImplementedException();
    }
}
