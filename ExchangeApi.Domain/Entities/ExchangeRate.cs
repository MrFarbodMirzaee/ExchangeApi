#nullable disable
using ExchangeApi.Domain.Contracts;

namespace ExchangeApi.Domain.Entities;

/// <summary>
/// Represents an exchange rate within the Exchange API system.
/// This entity captures the rates at which currencies can be exchanged.
/// </summary>
[Entity]
public class ExchangeRate : IBaseEntity<Guid>, IDeletable, IAuditable
{
    #region Properties

    /// <summary>
    /// Represents the unique identifier of the exchange rate.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Represents the identifier of the currency from which the exchange rate is calculated.
    /// </summary>
    public Guid FromCurrency { get; set; }

    /// <summary>
    /// Represents the identifier of the currency to which the exchange rate is calculated.
    /// </summary>
    public Guid ToCurrency { get; set; }

    /// <summary>
    /// Represents the exchange rate value between the two currencies.
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// The timestamp indicating when the exchange rate was created.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// A flag indicating whether the exchange rate is currently active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Represents the date and time when the exchange rate was last updated.
    /// </summary>
    public DateTime Updated { get; set; }

    /// <summary>
    /// A brief description of the exchange rate.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// A meta description for SEO or informational purposes.
    /// </summary>
    public string MetaDescription { get; set; }

    /// <summary>
    /// The identifier of the user who last updated this exchange rate.
    /// </summary>
    public Guid UpdatedByUserId { get; set; }

    /// <summary>
    /// The identifier of the user who deleted this exchange rate, if applicable.
    /// </summary>
    public Guid DeletedByUserId { get; set; }

    #endregion

    #region Navigations

    #endregion
}