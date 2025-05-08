namespace ExchangeApi.Domain.Enums;

/// <summary>
/// Represents various comparison operators used in queries and filters.
/// </summary>
public enum Operator
{
    /// <summary>
    /// Represents the equality operator.
    /// </summary>
    Eq = 1,

    /// <summary>
    /// Represents the greater than or equal to operator.
    /// </summary>
    GtOrEq = 2,

    /// <summary>
    /// Represents the less than or equal to operator.
    /// </summary>
    LtOrEq = 3,

    /// <summary>
    /// Represents the less than operator.
    /// </summary>
    Lt = 4,

    /// <summary>
    /// Represents the greater than operator.
    /// </summary>
    Gt = 5,

    /// <summary>
    /// Represents the not equal to operator.
    /// </summary>
    NotEq,

    /// <summary>
    /// Represents the contains operator for string comparisons.
    /// </summary>
    Contains
}