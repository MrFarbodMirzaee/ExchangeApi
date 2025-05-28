namespace ExchangeApi.Domain.Contracts;

/// <summary>
/// Defines properties for entities that support audit tracking for updates.
/// </summary>
public interface IAuditable
{
    /// <summary>
    /// Gets or sets the ID of the user who last updated the entity, if applicable.
    /// </summary>
    public Guid? UpdatedByUserId { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was last updated.
    /// </summary>
    public DateTimeOffset Updated { get; set; }
}