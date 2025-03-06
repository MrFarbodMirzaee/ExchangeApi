#nullable disable
using ExchangeApi.Domain.Contracts;

namespace ExchangeApi.Domain.Entities;

/// <summary>
/// Represents a currency in the Exchange API system.
/// This entity captures essential details about the currency, including its code, name, and related attributes.
/// </summary>
[Entity]
public class Currency : IBaseEntity<Guid>, IDeletable, IAuditable
{
    #region Properties

    /// <summary>
    /// Represents the unique identifier of the currency.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Represents the code that identifies the currency (e.g., USD, EUR).
    /// </summary>
    public string CurrencyCode { get; set; }

    /// <summary>
    /// Represents the name of the currency (e.g., US Dollar, Euro).
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The timestamp indicating when the currency was created.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// A flag indicating whether the currency is currently active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// The path to an image representing the currency (e.g., flag or symbol).
    /// </summary>
    public string ImagePath { get; set; }

    /// <summary>
    /// The timestamp of the last update made to the currency.
    /// </summary>
    public DateTime Updated { get; set; }

    /// <summary>
    /// A brief description of the currency.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// A meta description for SEO or informational purposes.
    /// </summary>
    public string MetaDescription { get; set; }

    /// <summary>
    /// The identifier of the user who deleted this currency, if applicable.
    /// </summary>
    public Guid DeletedByUserId { get; set; }

    /// <summary>
    /// The identifier of the user who last updated this currency.
    /// </summary>
    public Guid UpdatedByUserId { get; set; }

    #endregion

    #region Navigations

    /// <summary>
    /// Represents a collection of exchange rates associated with this currency.
    /// </summary>
    public ICollection<ExchangeRate> ExchangeRates { get; set; }

    /// <summary>
    /// Represents a collection of attributes associated with this currency.
    /// </summary>
    public ICollection<CurrencyAttribute> CurrencyAttributes { get; set; }

    #endregion
}