using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeApi.Domain.ValueObjects;
[NotMapped]
public class QueryCriterial
{
    public List<Filter> Filters { get; set; }
    public List<Sort> Sorts { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
}
