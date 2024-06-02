using ExchangeApi.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeApi.Domain.ValueObjects;
[NotMapped]
public class Filter
{
    public string PropertyName { get; set; }
    public Operator Operation { get; set; }
    public object Value { get; set; }
}
