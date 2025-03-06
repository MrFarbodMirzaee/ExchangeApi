#nullable disable
using ExchangeApi.Domain.Contracts;

namespace ExchangeApi.Domain.Entities;

/// <summary>
/// Represents a category in the Exchange API system.
/// This entity categorizes currencies and their attributes for better organization and retrieval.
/// </summary>
[Entity]
public class Category : IBaseEntity<Guid>, IDeletable, IAuditable
{
    #region Properties

    /// <summary>
    /// Represents the unique identifier of the category.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Represents the name of the category.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A meta description for SEO or informational purposes.
    /// </summary>
    public string MetaDescription { get; set; }

    /// <summary>
    /// A brief description of the category.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The timestamp indicating when the category was created.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// The timestamp of the last update made to the category.
    /// </summary>
    public DateTime Updated { get; set; }

    /// <summary>
    /// The identifier of the user who last updated this category.
    /// </summary>
    public Guid UpdatedByUserId { get; set; }

    /// <summary>
    /// The identifier of the user who deleted this category, if applicable.
    /// </summary>
    public Guid DeletedByUserId { get; set; }

    #endregion

    #region Navigatoions

    #endregion
}