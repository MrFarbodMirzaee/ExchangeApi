#nullable disable
using ExchangeApi.Domain.Contracts;

namespace ExchangeApi.Domain.Entities;

/// <summary>
/// Represents an exchange rate within the Exchange API system.
/// This entity captures the rates at which currencies can be exchanged.
/// </summary>
[Entity]
public class ExchangeRate : BaseEntity<Guid>, IDeletable, IAuditable
{
    #region Properties

    /// <summary>
    /// Represents the identifier of the currency from which the exchange rate is calculated.
    /// </summary>
    public Guid FromCurrencyId { get; set; }

    /// <summary>
    /// Represents the identifier of the currency to which the exchange rate is calculated.
    /// </summary>
    public Guid ToCurrencyId { get; set; }

    /// <summary>
    /// Represents the exchange rate value between the two currencies.
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// A flag indicating whether the exchange rate is currently active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// The identifier of the user who last updated this exchange rate.
    /// </summary>
    public Guid? UpdatedByUserId { get; set; }

    /// <summary>
    /// The identifier of the user who deleted this exchange rate, if applicable.
    /// </summary>
    public Guid? DeletedByUserId { get; set; }

    DateTimeOffset IAuditable.Updated { get; set; }
    #endregion

    #region Navigations
    
    /// <summary>
    /// The currency from which the exchange rate is calculated.
    /// </summary>
    public Currency FromCurrency { get; set; }

    /// <summary>
    /// The currency to which the exchange rate is calculated.
    /// </summary>
    public Currency ToCurrency { get; set; }

    #endregion
}