#nullable disable
namespace ExchangeApi.GraphQl.Entities;

public class Currency
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    ICollection<TradingPair> TradingPairs { get; set; }
    public DateTime UpdatedAt { get; set; }
    public decimal Volume24h { get; set; }
}
