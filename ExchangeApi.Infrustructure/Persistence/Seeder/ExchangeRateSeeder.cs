using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApi.Infrustructure.Persistence.Seeder;

public class ExchangeRateSeeder : IBaseSeeder<ExchangeRate>
{
    public IEnumerable<ExchangeRate> GetSeedData()
    {
        throw new NotImplementedException();
    }
}
