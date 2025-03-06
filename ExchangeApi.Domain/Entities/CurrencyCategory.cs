#nullable disable
using ExchangeApi.Domain.Contracts;

namespace ExchangeApi.Domain.Entities;

/// <summary>
/// Represents a bridge class that links currencies to their respective categories.
/// This entity facilitates many-to-many relationships between currencies and categories.
/// </summary>
public class CurrencyCategory : IBaseEntity<Guid>
{
    #region Properties

    /// <summary>
    /// Represents the unique identifier of the currency category.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// A meta description for SEO or informational purposes.
    /// </summary>
    public string MetaDescription { get; set; }

    /// <summary>
    /// A brief description of the currency category.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The timestamp indicating when the currency category was created.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// The timestamp of the last update made to the currency category.
    /// </summary>
    public DateTime Updated { get; set; }

    #endregion

    #region Navigations

    /// <summary>
    /// The identifier of the associated currency.
    /// </summary>
    public Guid CurrencyId { get; set; }

    /// <summary>
    /// The currency associated with this category.
    /// </summary>
    public Currency Currency { get; set; }

    /// <summary>
    /// The identifier of the associated category.
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// The category associated with this currency.
    /// </summary>
    public Category Category { get; set; }

    #endregion
}