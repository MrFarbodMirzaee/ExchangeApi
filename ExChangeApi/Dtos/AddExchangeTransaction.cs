namespace ExchangeApi.Dtos;

public class AddExchangeTransaction
{
    public int FromCurrencyId { get; set; }
    public int ToCurrencyId { get; set; }
    public decimal Amount { get; set; }
    public decimal ResultAmount { get; set; }
    public int ExchangeRateId { get; set; }
    public DateTime TransactionDate { get; set; }
}
