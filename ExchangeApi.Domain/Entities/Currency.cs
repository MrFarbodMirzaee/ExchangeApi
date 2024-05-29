using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.Entities;


namespace ExChangeApi.Domain.Entities;

public class Currency : IBaseEntity<int>
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
    public bool IsActive { get; private set; }
    public string ImagePath { get; set; }
    public void Activate() => IsActive = true; 
    public void Deactivate() => IsActive = false;
    public DateTime Updated { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }

    /// <summary>
    /// Represents a collection of exchange rates associated with this currency.
    /// </summary>
    ICollection<ExchangeRate> ExchangeRates { get; set; }
    ICollection<CurrencyAttribute> CurrencyAttributes { get; set; }
}
