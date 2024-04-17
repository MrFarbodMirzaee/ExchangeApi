using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.Entitiess;


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
    public bool IsActive { get; set; }
    public DateTime Updated { get; set; }

    /// <summary>
    /// Represents a collection of exchange rates associated with this currency.
    /// </summary>
    ICollection<ExchangeRate> ExchangeRates { get; set; }
}
