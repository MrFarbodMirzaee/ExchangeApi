
namespace ExchangeApi.Application.Dtos;

public record ExchangeTransactionDto 
{
    public int Id { get; set; }
    public int FromCurrencyId { get; set; }
    public int ToCurrencyId { get; set; }
    public decimal Amount { get; set; }
    public decimal ResultAmount { get; set; }
    public int ExchangeRateId { get; set; }
    public bool IsActive { get; set; }
    public DateTime TransactionDate { get; set; }
}
