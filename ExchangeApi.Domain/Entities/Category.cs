#nullable disable
using ExchangeApi.Domain.Contracts;

namespace ExchangeApi.Domain.Entities;

public class Category : IBaseEntity<int>,IDeletable,IAuditable
{
    public int Id { get ; set ; }
    public string  Name { get; set; }
    public string MetaDescription { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public int UpdatedByUserId { get; set; }
    public int DeletedByUserId { get; set; }
}
