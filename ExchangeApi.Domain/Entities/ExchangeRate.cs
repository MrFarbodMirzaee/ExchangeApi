#nullable disable
using ExchangeApi.Domain.Contracts;

namespace ExchangeApi.Domain.Entities;
[Entity]
public class ExchangeRate : IBaseEntity<int>, IDeletable, IAuditable
{
    /// <summary>
    /// Represents the unique identifier of the exchange rate.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Represents the identifier of the currency from which the exchange rate is calculated.
    /// </summary>
    public int FromCurrency { get; set; }
    /// <summary>
    /// Represents the identifier of the currency to which the exchange rate is calculated.
    /// </summary>
    public int ToCurrency { get; set; }
    /// <summary>
    /// Represents the exchange rate value between the two currencies.
    /// </summary>
    public decimal Rate { get; set; }
 
    public DateTime Created { get; set; }
    public bool IsActive { get; set; }
    /// <summary>
    ///  Represents the date and time when the exchange rate was last updated.
    /// </summary>
    public DateTime Updated { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public int UpdatedByUserId { get; set; }
    public int DeletedByUserId { get; set; }

    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}
