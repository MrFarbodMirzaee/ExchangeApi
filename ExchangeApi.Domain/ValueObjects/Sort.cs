using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeApi.Domain.ValueObjects;
[NotMapped]
public class Sort
{
    public string PropertyName { get; set; }
    public bool IsAscending { get; set; }
}
