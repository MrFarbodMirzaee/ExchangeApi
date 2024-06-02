#nullable disable
using ExchangeApi.Domain.Contracts;
using ExChangeApi.Domain.Entities;

namespace ExchangeApi.Domain.Entities;

public class CurrencyCategory : IBaseEntity<int> //Bridge class
{
    public int Id { get; set; }
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public string MetaDescription { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}
