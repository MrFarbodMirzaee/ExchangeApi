using ExchangeApi.Domain.Contracts;


namespace ExchangeApi.Domain.Entities;

public class CurrencyAttribute : IBaseEntity<int>
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public int CurrencyId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public bool IsActive { get; set; }
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
    public string Description { get; set; }
    public string MetaDescription { get; set; }
}
