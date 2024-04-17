using ExchangeApi.Domain.Contracts;

namespace ExchangeApi.Domain.Entitiess;

public class ExchangeTransaction : IBaseEntity<int>
{
    /// <summary>
    ///  Represents the unique identifier of the exchange transaction.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Represents the identifier of the currency from which the transaction originates.
    /// </summary>
    public int FromCurrencyId { get; set; }
    /// <summary>
    ///  Represents the identifier of the currency to which the transaction is made.
    /// </summary>
    public int ToCurrencyId { get; set; }
    /// <summary>
    /// Represents the amount of currency being exchanged in the transaction.
    /// </summary>
    public decimal Amount { get; set; }
    /// <summary>
    /// Represents the resulting amount of currency after the exchange transaction.
    /// </summary>
    public decimal ResultAmount { get; set; }
    /// <summary>
    /// Represents the identifier of the exchange rate used in the transaction.
    /// </summary>
    public int ExChangeRateId { get; set; }
    /// <summary>
    /// Represents the date and time when the transaction occurred.
    /// </summary>
    public DateTime? TransactionDate { get; set; }
    public DateTime Created { get; set; }
    public bool IsActive { get; set; }
    public DateTime Updated { get; set; }
}
