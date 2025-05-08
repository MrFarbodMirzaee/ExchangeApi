using ExchangeApi.Domain.Contracts;

namespace ExchangeApi.Domain.Entities;

/// <summary>
/// Represents a category in the Exchange API system.
/// This entity categorizes currencies and their attributes for better organization and retrieval.
/// </summary>
[Entity]
public class Category : BaseEntity<Guid>, IDeletable, IAuditable
{
    #region Properties

    /// <summary>
    /// Represents the name of the category.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A brief description of the category.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// The identifier of the user who last updated this category.
    /// </summary>
    public Guid? UpdatedByUserId { get; set; }

    /// <summary>
    /// The identifier of the user who deleted this category, if applicable.
    /// </summary>
    public Guid? DeletedByUserId { get; set; }

    DateTimeOffset IAuditable.Updated { get; set; }
    #endregion

    #region Navigatoions

    /// <summary>
    /// Represents a collection of currencies associated with this category.
    /// </summary>
    public ICollection<Currency> Currencies { get; set; }

    /// <summary>
    /// Represents a collection of currency attributes associated with this category.
    /// </summary>
    public ICollection<CurrencyAttribute> CurrencyAttributes { get; set; }

    #endregion
}