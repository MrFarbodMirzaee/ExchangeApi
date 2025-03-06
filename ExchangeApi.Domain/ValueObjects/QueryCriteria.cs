using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeApi.Domain.ValueObjects;

/// <summary>
/// Represents the criteria for querying data in the Exchange API system.
/// This class encapsulates filters, sorting options, and pagination information.
/// </summary>
[NotMapped]
public class QueryCriteria
{
    /// <summary>
    /// A list of filters to be applied to the query.
    /// </summary>
    public List<Filter> Filters { get; set; }

    /// <summary>
    /// A list of sorting options to be applied to the query results.
    /// </summary>
    public List<Sort> Sorts { get; set; }

    /// <summary>
    /// The number of records to skip when retrieving results (for pagination).
    /// </summary>
    public int Skip { get; set; }

    /// <summary>
    /// The maximum number of records to take from the query results.
    /// </summary>
    public int Take { get; set; }
}