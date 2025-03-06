using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeApi.Domain.ValueObjects;

/// <summary>
/// Represents a sorting option used in queries within the Exchange API system.
/// This class encapsulates the property name and the sorting order (ascending or descending).
/// </summary>
[NotMapped]
public class Sort
{
    /// <summary>
    /// The name of the property to sort by.
    /// </summary>
    public string PropertyName { get; set; }

    /// <summary>
    /// Indicates whether the sorting should be in ascending order.
    /// If false, the sorting will be in descending order.
    /// </summary>
    public bool IsAscending { get; set; }
}