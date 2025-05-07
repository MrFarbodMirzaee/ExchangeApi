namespace ExchangeApi.Domain.Contracts;

public interface IDeletable
{
    public Guid DeletedByUserId { get; set; }
    public DateTimeOffset Created { get; set; }
}