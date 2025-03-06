using ExchangeApi.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeApi.Domain.ValueObjects;

/// <summary>
/// Represents a filter used for querying data in the Exchange API system.
/// This class encapsulates the property name, operation, and value for filtering.
/// </summary>
[NotMapped]
public class Filter
{
    /// <summary>
    /// The name of the property to be filtered.
    /// </summary>
    public string PropertyName { get; set; }

    /// <summary>
    /// The operation to be applied for filtering (e.g., equality, greater than).
    /// </summary>
    public Operator Operation { get; set; }

    /// <summary>
    /// The value to be used in the filter operation.
    /// </summary>
    public object Value { get; set; }
}