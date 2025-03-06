namespace ExchangeApi.GraphQl.Enum;

/// <summary>
/// Represents the possible statuses for a trading pair in the Exchange API system.
/// This enum defines the operational state of a trading pair, indicating whether
/// it is currently active, suspended, or has been delinted.
/// </summary>
public enum TradingPairStatus
{
    /// <summary>
    /// Indicates that the trading pair is active and available for trading.
    /// </summary>
    Active,

    /// <summary>
    /// Indicates that the trading pair is temporarily suspended and not available for trading.
    /// </summary>
    Suspended,

    /// <summary>
    /// Indicates that the trading pair has been permanently removed from trading.
    /// </summary>
    Delisted
}