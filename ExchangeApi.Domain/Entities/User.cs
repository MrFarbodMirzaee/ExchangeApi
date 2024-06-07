#nullable disable
using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.Entities;


namespace ExChangeApi.Domain.Entities;

public class User : IBaseEntity<int>, IDeletable, IAuditable
{
    public int Id { get; set;  }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public DateTime Created { get; set; }
    public bool IsActive { get; set; }
    public ICollection<ExchangeTransaction> ExchangeTransactions { get; set; }
    public DateTime Updated { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public int DeletedByUserId { get; set; }
    public int UpdatedByUserId { get; set; }
    
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}
