#nullable disable
using ExchangeApi.Domain.Contracts;

namespace ExchangeApi.Domain.Entities;

/// <summary>
/// Represents an exchange transaction within the Exchange API system.
/// This entity captures details about currency exchanges performed by users.
/// </summary>
[Entity]
public class ExchangeTransaction : IBaseEntity<Guid>, IDeletable, IAuditable
{
    #region Properties

    /// <summary>
    /// Represents the unique identifier of the exchange transaction.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Represents the identifier of the currency from which the transaction originates.
    /// </summary>
    public Guid FromCurrencyId { get; set; }

    /// <summary>
    /// Represents the identifier of the currency to which the transaction is made.
    /// </summary>
    public Guid ToCurrencyId { get; set; }

    /// <summary>
    /// Represents the amount of currency being exchanged in the transaction.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Represents the resulting amount of currency after the exchange transaction.
    /// </summary>
    public decimal ResultAmount { get; set; }

    /// <summary>
    /// Represents the identifier of the exchange rate used in the transaction.
    /// </summary>
    public Guid ExChangeRateId { get; set; }

    /// <summary>
    /// Represents the date and time when the transaction occurred.
    /// </summary>
    public DateTime? TransactionDate { get; set; }

    /// <summary>
    /// The timestamp indicating when the transaction was created.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// A flag indicating whether the transaction is currently active.
    /// </summary>
    public bool IsActive { get; private set; }

    /// <summary>
    /// The timestamp of the last update made to the transaction.
    /// </summary>
    public DateTime Updated { get; set; }

    /// <summary>
    /// A brief description of the transaction.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Activates the transaction.
    /// </summary>
    public void Activate() => IsActive = true;

    /// <summary>
    /// Deactivates the transaction.
    /// </summary>
    public void Deactivate() => IsActive = false;

    /// <summary>
    /// A meta description for SEO or informational purposes.
    /// </summary>
    public string MetaDescription { get; set; }

    /// <summary>
    /// The identifier of the user who last updated this transaction.
    /// </summary>
    public Guid UpdatedByUserId { get; set; }

    /// <summary>
    /// The identifier of the user who deleted this transaction, if applicable.
    /// </summary>
    public Guid DeletedByUserId { get; set; }

    #endregion

    #region Navigations

    /// <summary>
    /// The identifier of the user associated with this transaction.
    /// </summary>
    public Guid UserId { get; set; }

    #endregion
}