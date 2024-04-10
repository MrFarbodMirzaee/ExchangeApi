
using ExChangeApi.Domain.Contracts;

namespace ExChangeApi.Domain.Entities;

public class User : IBaseEntity<int>
{
    public int Id { get; set;  }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public DateTime Created { get; set; }
    public bool IsActive { get; set; }
    //public ICollection<ExchangeTransaction> ExchangeTransactions { get; set; }
    public DateTime Updated { get; set; }
}
