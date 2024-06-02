#nullable disable
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Commands.AddExchangeTransaction;

public class AddExchangeTransactionCommand : IRequest<Response<int>>
{
    public int FromCurrencyId { get; set; }
    public int ToCurrencyId { get; set; }
    public decimal Amount { get; set; }
    public decimal ResultAmount { get; set; }
    public int ExchangeRateId { get; set; }
    public bool IsActive { get; set; }
    public DateTime TransactionDate { get; set; }
}
