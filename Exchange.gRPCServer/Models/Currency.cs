#nullable disable
namespace Exchange.gRPCServer.Models;

public class Currency
{
    public int Id { get; set; }
    public string CurrencyCode { get; set; }
    public double Price { get; set; }
}
