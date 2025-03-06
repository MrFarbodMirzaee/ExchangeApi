#nullable disable
namespace Exchange.gRPCServer.Entities;

public class Currency
{
    public int Id { get; set; }
    public string CurrencyCode { get; set; }
    public double Price { get; set; }
}