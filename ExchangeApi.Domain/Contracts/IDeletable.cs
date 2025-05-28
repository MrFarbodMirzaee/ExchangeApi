namespace ExchangeApi.Domain.Contracts;

/// <summary>
/// Defines properties for entities that support soft deletion tracking.
/// </summary>
public interface IDeletable
{
    /// <summary>
    /// Gets or sets the ID of the user who marked the entity as deleted, if applicable.
    /// </summary>
    public Guid? DeletedByUserId { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    public DateTimeOffset Created { get; set; }
}