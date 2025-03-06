#nullable disable
using ExchangeApi.GraphQl.Enum;

namespace ExchangeApi.GraphQl.Entities;

/// <summary>
/// Represents a trading pair entity in the Exchange API system.
/// This class encapsulates the properties related to a trading pair, including
/// its identification, base and quote assets, trading size limits, status,
/// and timestamps for creation and updates.
/// </summary>
public class TradingPair
{
    #region Properties

    /// <summary>
    /// Gets or sets the unique identifier for the trading pair.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the symbol of the base asset in the trading pair.
    /// </summary>
    public string BaseAssetSymbol { get; set; }

    /// <summary>
    /// Gets or sets the symbol of the quote asset in the trading pair.
    /// </summary>
    public string QuoteAssetSymbol { get; set; }

    /// <summary>
    /// Gets or sets the number of decimal places for the price of the trading pair.
    /// </summary>
    public int PriceDecimals { get; set; }

    /// <summary>
    /// Gets or sets the number of decimal places for the amount of the trading pair.
    /// </summary>
    public int AmountDecimals { get; set; }

    /// <summary>
    /// Gets or sets the minimum trade size allowed for the trading pair.
    /// </summary>
    public decimal MinTradeSize { get; set; }

    /// <summary>
    /// Gets or sets the maximum trade size allowed for the trading pair.
    /// </summary>
    public decimal MaxTradeSize { get; set; }

    /// <summary>
    /// Gets or sets the status of the trading pair (e.g., active, inactive).
    /// </summary>
    public TradingPairStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the trading pair was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the trading pair was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    #endregion

    #region Navigations

    public Currency Currency { get; set; }

    #endregion
}