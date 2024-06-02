using ExchangeApi.Domain.Contracts;
using ExChangeApi.Domain.Entities;


namespace ExchangeApi.Domain.Entities;

public class CurrencyAttribute : IBaseEntity<int>,IDeletable,IAuditable
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public bool IsActive { get; set; }
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public int UserId { get; set; }
    public int DeletedByUserId { get; set; }
    public int UpdatedByUserId { get; set; }
}
