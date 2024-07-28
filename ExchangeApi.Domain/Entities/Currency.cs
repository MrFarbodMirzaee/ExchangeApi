#nullable disable
using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.Entities;

namespace ExChangeApi.Domain.Entities;
[Entity]
public class Currency : IBaseEntity<int>,IDeletable,IAuditable
{
    /// <summary>
    /// Represents the unique identifier of the currency.
    /// </summary>
    public int Id { get ; set ; }
    /// <summary>
    /// Represents the code that identifies the currency.
    /// </summary>
    public string CurrencyCode { get; set; }
    /// <summary>
    /// Represents the name of the currency.
    /// </summary>
    public string Name { get; set; }
    public DateTime Created { get; set; }
    public bool IsActive { get; set; }
    public string ImagePath { get; set; }
    public DateTime Updated { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }

    /// <summary>
    /// Represents a collection of exchange rates associated with this currency.
    /// </summary>
    ICollection<ExchangeRate> ExchangeRates { get; set; }
    ICollection<CurrencyAttribute> CurrencyAttributes { get; set; }
    public int DeletedByUserId { get; set; }
    public int UpdatedByUserId { get; set; }
}
