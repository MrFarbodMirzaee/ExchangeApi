using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.Entitiess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApi.Infrustructure.Persistence.Seeder;

public class ExchangeTransactionSeeder : IBaseSeeder<ExchangeTransaction>
{
    public IEnumerable<ExchangeTransaction> GetSeedData()
    {
        throw new NotImplementedException();
    }
}
