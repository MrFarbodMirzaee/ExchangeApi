namespace ExchangeApi.Domain.Contracts;

/// <summary>
/// Represents a base entity with common metadata properties for all derived entities.
/// </summary>
public abstract class BaseEntity<TId>
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public TId Id { get; set; }

    /// <summary>
    /// Gets or sets the meta description or summary information for the entity.
    /// </summary>
    public string MetaDescription { get; set; }

    /// <summary>
    /// Gets or sets the creation date and time of the entity.
    /// </summary>
    public DateTimeOffset Created { get; set; }
    
    /// <summary>
    /// Gets or sets the last updated date and time of the entity, if any.
    /// </summary>
    public DateTimeOffset? Updated { get; set; }
}