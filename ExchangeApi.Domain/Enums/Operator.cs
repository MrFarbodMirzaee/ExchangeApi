namespace ExchangeApi.Domain.Enums;

/// <summary>
/// Represents various comparison operators used in queries and filters.
/// </summary>
public enum Operator
{
    /// <summary>
    /// Represents the equality operator.
    /// </summary>
    Eq,

    /// <summary>
    /// Represents the greater than or equal to operator.
    /// </summary>
    GtOrEq,

    /// <summary>
    /// Represents the less than or equal to operator.
    /// </summary>
    LtOrEq,

    /// <summary>
    /// Represents the less than operator.
    /// </summary>
    Lt,

    /// <summary>
    /// Represents the greater than operator.
    /// </summary>
    Gt,

    /// <summary>
    /// Represents the not equal to operator.
    /// </summary>
    NotEq,

    /// <summary>
    /// Represents the contains operator for string comparisons.
    /// </summary>
    Contains
}