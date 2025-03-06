#nullable disable
namespace ExchangeApi.GraphQl.Entities;

/// <summary>
/// Represents a currency entity in the Exchange API system.
/// This class encapsulates the properties related to a currency, including its
/// identification, name, description, creation and update timestamps, trading volume,
/// and associated trading pairs.
/// </summary>
public class Currency
{
    #region Properties

    /// <summary>
    /// Gets or sets the unique identifier for the currency.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the currency (e.g., USD, EUR).
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a description of the currency.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the currency was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the currency was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Gets or sets the 24-hour trading volume of the currency.
    /// </summary>
    public decimal Volume24h { get; set; }

    #endregion

    #region Navigations

    ICollection<TradingPair> TradingPairs { get; set; }

    #endregion
}