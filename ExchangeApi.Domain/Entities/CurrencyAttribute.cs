using ExchangeApi.Domain.Contracts;

namespace ExchangeApi.Domain.Entities;

/// <summary>
/// Represents an attribute associated with a currency in the Exchange API system.
/// This entity captures key-value pairs that provide additional information about currencies.
/// </summary>
[Entity]
public class CurrencyAttribute : IBaseEntity<Guid>, IDeletable, IAuditable
{
    #region Properties

    /// <summary>
    /// Represents the unique identifier of the currency attribute.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Represents the key of the currency attribute.
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Represents the value associated with the currency attribute key.
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// The timestamp indicating when the currency attribute was created.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// The timestamp of the last update made to the currency attribute.
    /// </summary>
    public DateTime Updated { get; set; }

    /// <summary>
    /// A flag indicating whether the currency attribute is currently active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// A brief description of the currency attribute.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// A meta description for SEO or informational purposes.
    /// </summary>
    public string MetaDescription { get; set; }

    /// <summary>
    /// The identifier of the user who deleted this currency attribute, if applicable.
    /// </summary>
    public Guid DeletedByUserId { get; set; }

    /// <summary>
    /// The identifier of the user who last updated this currency attribute.
    /// </summary>
    public Guid UpdatedByUserId { get; set; }

    #endregion

    /// <summary>
    /// Activates the currency attribute.
    /// </summary>
    public void Activate() => IsActive = true;

    /// <summary>
    /// Deactivates the currency attribute.
    /// </summary>
    public void Deactivate() => IsActive = false;

    #region Navigations

    /// <summary>
    /// The identifier of the user associated with this currency attribute.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// The identifier of the associated currency.
    /// </summary>
    public Guid CurrencyId { get; set; }

    /// <summary>
    /// The currency associated with this attribute.
    /// </summary>
    public Currency Currency { get; set; }

    #endregion
}