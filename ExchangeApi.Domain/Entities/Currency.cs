using ExchangeApi.Domain.Contracts;

namespace ExchangeApi.Domain.Entities;

/// <summary>
/// Represents a currency in the Exchange API system.
/// This entity captures essential details about the currency, including its code, name, and related attributes.
/// </summary>
[Entity]
public class Currency : BaseEntity<Guid>, IDeletable, IAuditable
{
    #region Properties

    /// <summary>
    /// Represents the code that identifies the currency (e.g., USD, EUR).
    /// </summary>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Represents the name of the currency (e.g., US Dollar, Euro).
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A flag indicating whether the currency is currently active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// The path to an image representing the currency (e.g., flag or symbol).
    /// </summary>
    public string ImagePath { get; set; }

    /// <summary>
    /// A brief description of the currency.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The identifier of the user who deleted this currency, if applicable.
    /// </summary>
    public Guid? DeletedByUserId { get; set; }

    /// <summary>
    /// The identifier of the user who last updated this currency.
    /// </summary>
    public Guid? UpdatedByUserId { get; set; }
    DateTimeOffset IAuditable.Updated { get; set; }
    #endregion

    #region Navigations
    
    /// <summary>
    /// Represents a collection of exchange transactions where this currency is the source currency.
    /// </summary>
    public ICollection<ExchangeTransaction> FromExchangeTransactions { get; set; }

    /// <summary>
    /// Represents a collection of exchange transactions where this currency is the destination currency.
    /// </summary>
    public ICollection<ExchangeTransaction> ToExchangeTransactions { get; set; }

    /// <summary>
    /// Represents a collection of exchange rates where this currency is the source currency.
    /// </summary>
    public ICollection<ExchangeRate> FromExchangeRates { get; set; } 

    /// <summary>
    /// Represents a collection of exchange rates where this currency is the destination currency.
    /// </summary>
    public ICollection<ExchangeRate> ToExchangeRates { get; set; }

    /// <summary>
    /// Represents a collection of attributes associated with this currency.
    /// </summary>
    public ICollection<CurrencyAttribute> CurrencyAttributes { get; set; }

    /// <summary>
    /// Represents a collection of files associated with this currency.
    /// </summary>
    public ICollection<File> Files { get; set; }
    
    /// <summary>
    /// Represents the identifier of the category associated with this currency.
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// The category associated with this currency.
    /// </summary>
    public Category Category { get; set; }
    #endregion
}