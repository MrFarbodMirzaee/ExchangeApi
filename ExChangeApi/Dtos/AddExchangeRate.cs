namespace ExchangeApi.Dtos;

public class AddExchangeRate
{
    public int FromCurrency { get; set; }
    public int ToCurrency { get; set; }
    public decimal Rate { get; set; }
    public DateTime LastUpdate { get; set; }
}
